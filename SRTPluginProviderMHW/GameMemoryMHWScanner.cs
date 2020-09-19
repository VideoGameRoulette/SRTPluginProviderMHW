using ProcessMemory;
using System;
using static SRTPluginProviderMHW.Structs;

namespace SRTPluginProviderMHWorld
{
    internal class GameMemoryMHWScanner : IDisposable
    {
        // Variables
        private ProcessMemory.ProcessMemory memoryAccess;
        private GameMemoryMHW gameMemoryValues;
        public bool HasScanned;
        public bool ProcessRunning => memoryAccess != null && memoryAccess.ProcessRunning;
        public int ProcessExitCode => (memoryAccess != null) ? memoryAccess.ProcessExitCode : 0;

        // Pointer Address Variables
        private long save_data;

        // Pointer Classes
        private long BaseAddress { get; set; }
        private MultilevelPointer[] PointerMonster { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="proc"></param>
        internal GameMemoryMHWScanner(int? pid = null)
        {
            gameMemoryValues = new GameMemoryMHW();
            SelectPointerAddresses();
            if (pid != null)
            {
                Initialize(pid.Value);
            }

            // Setup the pointers.
            
        }

        internal void Initialize(int pid)
        {
            memoryAccess = new ProcessMemory.ProcessMemory(pid);

            if (ProcessRunning)
            {
                BaseAddress = NativeWrappers.GetProcessBaseAddress(pid, PInvoke.ListModules.LIST_MODULES_64BIT).ToInt64(); // Bypass .NET's managed solution for getting this and attempt to get this info ourselves via PInvoke since some users are getting 299 PARTIAL COPY when they seemingly shouldn't.

                PointerMonster = new MultilevelPointer[100];
                for (long i = 0; i < PointerMonster.Length; i++)
                {
                    PointerMonster[i] = new MultilevelPointer(memoryAccess, BaseAddress + save_data, 0xA8, 0xF4E48 + 0x1060 + (i * 0x4));
                }
            }
        }

        private void SelectPointerAddresses()
        {
            save_data = 0x4FBAA60;
        }


        /// <summary>
        /// 
        /// </summary>
        internal void UpdatePointers()
        {
            for (long i = 0; i < PointerMonster.Length; i++)
            {
                PointerMonster[i].UpdatePointers();
            }
        }

        internal IGameMemoryMHW Refresh()
        {
            if (gameMemoryValues.MonsterEntries == null)
            {
                gameMemoryValues.MonsterEntries = new MonsterEntry[100];
                for (int i = 0; i < gameMemoryValues.MonsterEntries.Length; i++)
                    gameMemoryValues.MonsterEntries[i] = new MonsterEntry();
            }
            // Save Data
            for (long j = 0; j < gameMemoryValues.MonsterEntries.Length; j++)
            {
                gameMemoryValues.MonsterEntries[j].SetValues((int)j, PointerMonster[j].DerefInt(0x0), PointerMonster[j].DerefInt(0x200));
            }
            HasScanned = true;
            return gameMemoryValues;
        }

#region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (memoryAccess != null)
                        memoryAccess.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~REmake1Memory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
#endregion
    }
}

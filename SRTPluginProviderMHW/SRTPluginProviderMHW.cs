using SRTPluginBase;
using System;
using System.Diagnostics;
using System.Linq;

namespace SRTPluginProviderMHWorld
{
    public class SRTPluginProviderMHW : IPluginProvider
    {
        private int? processId;
        private GameMemoryMHWScanner gameMemoryScanner;
        private Stopwatch stopwatch;
        private IPluginHostDelegates hostDelegates;
        //bool IPluginProvider.GameRunning() = true;
        public IPluginInfo Info => new PluginInfo();

        public bool GameRunning
        {
            get
            {
                if (gameMemoryScanner != null && !gameMemoryScanner.ProcessRunning)
                {
                    processId = GetProcessId();
                    if (processId != null)
                        gameMemoryScanner.Initialize((int)processId); // Re-initialize and attempt to continue.
                }

                return gameMemoryScanner != null && gameMemoryScanner.ProcessRunning;
            }
        }

        public int Startup(IPluginHostDelegates hostDelegates)
        {
            this.hostDelegates = hostDelegates;
            processId = Process.GetProcessesByName("MonsterHunterWorld")?.FirstOrDefault()?.Id;
            gameMemoryScanner = new GameMemoryMHWScanner(processId);
            stopwatch = new Stopwatch();
            stopwatch.Start();
            return 0;
        }

        public int Shutdown()
        {
            gameMemoryScanner?.Dispose();
            gameMemoryScanner = null;
            stopwatch?.Stop();
            stopwatch = null;
            return 0;
        }

        public object PullData()
        {
            try
            {
                if (!gameMemoryScanner.ProcessRunning)
                {
                    //hostDelegates.Exit();
                    processId = GetProcessId();
                    if (processId != null)
                    {
                        gameMemoryScanner.Initialize(processId.Value); // re-initialize and attempt to continue
                    }
                    else if (!gameMemoryScanner.ProcessRunning)
                    {
                        stopwatch.Restart();
                        return null;
                    }
                }

                if (stopwatch.ElapsedMilliseconds >= 2000L)
                {
                    gameMemoryScanner.UpdatePointers();
                    stopwatch.Restart();
                }
                return gameMemoryScanner.Refresh();
            }
            catch (Exception ex)
            {
                hostDelegates.OutputMessage("[{0}] {1} {2}", ex.GetType().Name, ex.Message, ex.StackTrace);
                return null;
            }
        }

        private int? GetProcessId() => Process.GetProcessesByName("MonsterHunterWorld")?.FirstOrDefault()?.Id;
    }
}

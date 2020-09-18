using System;
using static SRTPluginProviderMHW.Structs;

namespace SRTPluginProviderMHWorld
{
    public interface IGameMemoryMHW
    {
        MonsterEntry[] MonsterEntries { get; set; }
    }
}

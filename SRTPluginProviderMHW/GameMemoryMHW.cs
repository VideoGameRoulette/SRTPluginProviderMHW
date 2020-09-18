using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static SRTPluginProviderMHW.Structs;

namespace SRTPluginProviderMHWorld
{
    public struct GameMemoryMHW : IGameMemoryMHW
    {
        public MonsterEntry[] MonsterEntries { get; set; }
    }
}

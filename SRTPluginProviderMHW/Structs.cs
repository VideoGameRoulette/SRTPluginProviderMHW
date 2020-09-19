namespace SRTPluginProviderMHW
{
    public class Structs
    {
        public enum MonsterList : int
        {
            None = -1,
            Anjanath,
            Rathalos,
            Aptonoth,
            ZorahMagdaros = 4,
            GreatJagras = 7,
            Rathian = 9,
            PinkRathian,
            AzureRathalos,
            Diablos,
            BlackDiablos,
            Kirin,
            Behemoth,
            KushalaDaora,
            Lunastra,
            Teostra,
            Lavasioth,
            Deviljho,
            Barroth,
            Uragaan,
            Leshen,
            PukeiPukei,
            Nergigante,
            XenoJiiva,
            KuluYaKu,
            TzitziYaKu,
            Jyuratodus,
            TobiKadachi,
            Paolumu,
            Legiana,
            GreatGirros,
            Odogaron,
            Radobaan,
            VaalHazak,
            Dodogama,
            Bazelgeuse = 39,
            AncientLeshen = 51,
            Tigrex = 61,
            Nargacuga,
            Barioth,
            SavageDeviljho,
            Brachydios,
            Glavenus,
            AcidicGlavenus,
            FulgurAnjanath,
            CoralPukeiPukei,
            RuinerNergigante,
            ViperTobiKadachi,
            NightshadePaolumu,
            ShriekingLegiana,
            EbonyOdogaron,
            BlackveilVaalHazak,
            SeethingBazelgeuse,
            Beotodus,
            Banbaro,
            Velkhana,
            Namielle,
            SharaIshvalda,
            Alatreon = 87,
            GoldRathian,
            SilverRathalos,
            YianGaruga,
            Rajang,
            FuriousRajang,
            BruteTigrex,
            Zinogre,
            StygianZinogre,
            RagingBrachydios,
            SafiJiiva,
            ScarredYianGaruga = 99
        }

        public class MonsterEntry
        {
            public int MonsterID { get; private set; }
            public string MonsterName { get => ((MonsterList)MonsterID).ToString(); }
            public int Captured { get; private set; }
            public int Hunted { get; private set; }
            public int Total { get => Hunted + Captured; }

            public MonsterEntry()
            {
                this.MonsterID = -1;
                this.Captured = 0;
                this.Hunted = 0;
            }

            public void SetValues(int _MonsterID, int _Captured, int _Hunted)
            {
                this.MonsterID = _MonsterID;
                this.Captured = _Captured;
                this.Hunted = _Hunted;
            }
        }
    }

}
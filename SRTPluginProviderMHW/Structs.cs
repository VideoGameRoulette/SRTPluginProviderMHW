using System;
using System.Collections.Generic;
using System.Text;

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
            XenoJiva,
            KuluYaKu,
            TzitziYaKu,
            Jyuratodus,
            TobiKadachi,
            Paolumu,
            Legiana,
            GreatGirros,
            Obogaron,
            Radobaan,
            VaalHazak,
            Dodogame,
            Bazelgeuse = 39,
            AncientLeshen = 51,
            Tigrex = 61,
            Nargacuga,
            Barioth,
            SavageDeathPickle,
            Brachydios,
            Glavenus,
            AcidicGlavenus,
            FulgurAnjanath,
            CoralPukeiPukei,
            RuinerNergigante,
            ViperTobi,
            NightshadePaolumu,
            ShriekingLegiana,
            EbonyOdogaron,
            BlackvielVaalHazak,
            SeethingBazelgeuse,
            Beotodus,
            Banbaro,
            Velkhama,
            Namielle,
            SharaIshvalda,
            Alatreon = 87,
            GoldRathian,
            SilverRathalos,
            YuanGaruga,
            Rajang,
            FuriousRajang,
            BruteTigrex,
            Zinogre,
            StygianZinogre,
            RagingBrachydios,
            SafiJiiva,
            ScarredYioaGaruga = 99
        }

        public class MonsterEntry
        {
            public int MonsterID;
            public MonsterList MonsterName;
            public int Captured;
            public int Hunted;

            public MonsterEntry()
            {
                this.MonsterID = -1;
                this.MonsterName = MonsterList.None;
                this.Captured = 0;
                this.Hunted = 0;
            }

            public void SetValues(int _MonsterID, int _Captured, int _Hunted)
            {
                this.MonsterID = _MonsterID;
                this.MonsterName = (MonsterList)_MonsterID;
                this.Captured = _Captured;
                this.Hunted = _Hunted;
            }
        }
    }

}
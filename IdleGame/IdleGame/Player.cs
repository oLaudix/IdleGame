using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleGame
{
    public class Player
    {
        public List<int> heroSkills;
        public List<Gear> gearList;
        public List<Unit> Units;
        public Double purchaseCost;
        public int playerLevel;
        public Double currentDamage;
        public Double costMultiplier;
        public Double nextUpgradeCost;
        public Double criticalDamageMultiplier;
        public Double criticalChance;
        public int stage;
        public stage currentStage;
        Random Ramdom = new Random();
        public Double gold;
        public Double honor;
        public Player(double costMultiplier, double purchaseCost)
        {
            this.heroSkills = new List<int>();
            this.costMultiplier = costMultiplier;
            this.purchaseCost = purchaseCost;
            this.playerLevel = 1;
            this.stage = 0;
            this.gold = 0;
            gearList = new List<Gear>();
            Units = new List<Unit>();
            this.gearList.Add(new Gear(GearID.Gear1, "Amulet of the Valrunes", 0, BonusType.MonsterGold, 0.1f, 0.5f, 0.25f));
            this.gearList.Add(new Gear(GearID.Gear2, "Axe of Resolution", 0, BonusType.BerserkerRageDuration, 0.1f, 0.7f, 0.35f));
            this.gearList.Add(new Gear(GearID.Gear3, "Barbarian's Mettle", 10, BonusType.BerserkerRageCooldown, 0.05f, 0.7f, 0.35f));
            this.gearList.Add(new Gear(GearID.Gear4, "Brew of Absorbtion", 0, BonusType.AllDamage, 0.02f, 0.9f, 0.9f));
            this.gearList.Add(new Gear(GearID.Gear5, "Chest of Contentment", 0, BonusType.GoldFromChests, 0.2f, 0.4f, 0.2f));
            this.gearList.Add(new Gear(GearID.Gear6, "Crafter's Elixir", 0, BonusType.AllGold, 0.15f, 0.4f, 0.2f));
            this.gearList.Add(new Gear(GearID.Gear7, "Crown Egg", 0, BonusType.ChestChance, 0.2f, 0.4f, 0.2f));
            this.gearList.Add(new Gear(GearID.Gear8, "Death Seeker", 25, BonusType.CriticalChance, 0.02f, 0.3f, 0.15f));
            this.gearList.Add(new Gear(GearID.Gear9, "Divine Chalice", 0, BonusType.ChanceFor10xGold, 0.005f, 0.3f, 0.15f));
            this.gearList.Add(new Gear(GearID.Gear10, "Drunken Hammer", 0, BonusType.PlayerDamage, 0.04f, 0.6f, 0.30f));
            this.gearList.Add(new Gear(GearID.Gear11, "Hero's Thrust", 0, BonusType.CriticalDamage, 0.2f, 0.3f, 0.15f));
            this.gearList.Add(new Gear(GearID.Gear12, "Hunter's Ointment", 10, BonusType.WarCryCooldown, 0.05f, 1.2f, 0.6f));
            this.gearList.Add(new Gear(GearID.Gear13, "Laborer's Pendant", 10, BonusType.HandOfMidasCooldown, 0.05f, 0.7f, 0.35f));
            this.gearList.Add(new Gear(GearID.Gear14, "Ogre's Gauntlet", 0, BonusType.ShadowCloneDuration, 0.1f, 0.7f, 0.35f));
            this.gearList.Add(new Gear(GearID.Gear15, "Overseer's Lotion", 10, BonusType.ShadowCloneCooldown, 0.05f, 0.7f, 0.35f));
            this.gearList.Add(new Gear(GearID.Gear16, "Parchment of Importance", 0, BonusType.CriticalStrikeDuration, 0.1f, 0.7f, 0.35f));
            this.gearList.Add(new Gear(GearID.Gear17, "Ring of Opulence", 0, BonusType.HandOfMidasDuration, 0.1f, 0.7f, 0.35f));
            this.gearList.Add(new Gear(GearID.Gear18, "Ring of Wonderous Charm", 25, BonusType.UpgradeCost, 0.02f, 0.3f, 0.15f));
            this.gearList.Add(new Gear(GearID.Gear19, "Sacred Scroll", 10, BonusType.CriticalStrikeCooldown, 0.05f, 0.7f, 0.35f));
            this.gearList.Add(new Gear(GearID.Gear20, "Saintly Shield", 10, BonusType.HeavenlyStrikeCooldown, 0.05f, 0.7f, 0.35f));
            this.gearList.Add(new Gear(GearID.Gear21, "Tincture of the Maker", 0, BonusType.AllDamage, 0.05f, 0.1f, 0.05f));
            this.gearList.Add(new Gear(GearID.Gear22, "Undead Aura", 0, BonusType.BonusRelic, 0.05f, 0.3f, 0.15f));
            this.gearList.Add(new Gear(GearID.Gear23, "Universal Fissure", 0, BonusType.WarCryDuration, 0.1f, 1.2f, 0.6f));
            Unit tmp = new Unit(1, "Takeda", 1, 50);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 1.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.2f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 20.0f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.5f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 200.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(2, "Contessa", 2, 175);
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.2f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 20.0f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.2f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 200.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(3, "Hornetta", 3, 675);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.2f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.4f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.02f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.6f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(4, "Mila", 4, 2850);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 1.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 8.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 6.0f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 5.0f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.5f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(5, "Terra", 5, 13300);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.1f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.15f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 100.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(6, "Inquisireaux", 6, 68100);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 7.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.05f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.02f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 100.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(7, "Charlotte ", 7, 384000);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.07f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 0.6f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.3f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(8, "Jordaan", 8, 2800000);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.15f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 19.0f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(9, "Jukka", 9, 23800000);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 1.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.3f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.05f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 50.0f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.25f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 100.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(10, "Milo", 10, 143000000);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 1.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.01f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.15f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.25f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 0.15f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(11, "Macelord ", 11, 943000000);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 7.5f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.15f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.25f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.8f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(12, "Gertrude ", 12, 84E+09f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 13.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.05f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.2f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(13, "Twitterella  ", 13, 5.47E+10f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 1.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 8.5f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.3f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.05f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 15.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(14, "Master   ", 14, 8.20E+11f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 8.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 4.0f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.1f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.1f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.1f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(15, "Elpha   ", 15, 8.20E+12f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.02f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.15f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 100.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(16, "Poppy", 16, 1.64E+14f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.25f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.20f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.07f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.15f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(17, "Skulptor", 17, 1.64E+15f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 1.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 9.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.1f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.1f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.1f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.25f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(18, "Sterling", 18, 4.92E+16f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 4.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 5.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 4.5f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.15f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(19, "Orba", 19, 2.46E+18f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 10.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.1f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(20, "Remus", 20, 7.38E+19f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 6.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.2f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 4.5f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.1f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(21, "Mikey", 21, 2.44E+21f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.02f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 100.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(22, "Peter", 22, 2.44E+23f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 7.5f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 5.0f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.3f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(23, "Teeny ", 23, 4.87E+25f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 8.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.2f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.02f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 100.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(24, "Deznis", 24, 1.95E+28f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 2.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 5.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 12.0f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.15f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 9.0f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.15f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(25, "Hamlette ", 25, 2.14E+31f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.05f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.15f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.02f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 150.0f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(26, "Eistor", 26, 2.36E+36f);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 6.5f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.15f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(27, "Flavius", 27, 2.59E+46);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 7.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.05f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.02f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.3f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.2f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(28, "Chester", 28, 2.85E+61);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.5f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 4.0f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 6.0f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalDamage, 0.2f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.03f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.15f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(29, "Mohacas", 29, 3.14E+81);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 3.3f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 5.5f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.1f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.1f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.2f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.3f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(30, "Jaqulin", 30, 3.14E+96);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 10.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.2f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.05f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.2f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.3f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(31, "Pixie", 31, 3.76E+101);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 9.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 20.0f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.01f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.6f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.ChestGold, 0.25f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.15f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(32, "Jackalope", 32, 4.14E+136);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 0.4f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 0.2f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.25f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.6f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.CriticalChance, 0.02f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.3f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.1f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
            tmp = new Unit(33, "Dark Lord", 33, 4.56E+141);
            tmp.heroSkills.Add(new UnitSkill(BonusType.HeroDamage, 20.0f, 10, tmp.GetUpgradeCostByLevel(10) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamage, 0.2f, 25, tmp.GetUpgradeCostByLevel(25) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.PlayerDamageDPS, 0.01f, 50, tmp.GetUpgradeCostByLevel(50) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllGold, 0.2f, 100, tmp.GetUpgradeCostByLevel(100) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.2f, 200, tmp.GetUpgradeCostByLevel(200) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.3f, 400, tmp.GetUpgradeCostByLevel(400) * 10));
            tmp.heroSkills.Add(new UnitSkill(BonusType.AllDamage, 0.4f, 800, tmp.GetUpgradeCostByLevel(800) * 10));
            Units.Add(tmp);
        }

        public double getDamageArtifact()
        {
            double num = 0f;
            foreach (var item in this.gearList)
            {
                if (item.unlocked)
                {
                    num += item.GetDamageBonus();
                }
            }
            return num;
        }

        public double GetBonusType(BonusType bonusTypee)
        {
            double num = 0f;
            foreach (var item in this.gearList)
            {
                if (item.unlocked)
                {
                    if (item.GetbonusType() == bonusTypee)
                    {
                        num += item.GetBonusMagnitude();
                    }
                }
            }
            double num2 = 0f;
            foreach (var unit in Units)
            {
                foreach (var skill in unit.heroSkills)
                {
                    if (skill.isUnlocked)
                    {
                        if (skill.bonusType == bonusTypee)
                        {
                            num2 += skill.magnitude;
                        }
                    }
                }
            }
            return num + num2;
        }

        public double GetHeroDamage(Unit Unit)
        {
            return Unit.GetDPSByLevel(Unit.heroLevel);
        }

        public double GetTotalHeroDamage()
        {
            double num = 0;
            foreach (var unit in Units)
            {
                num += GetHeroDamage(unit);
            }
            return num;
        }

        public double GetTotalDps()
        {
            
            double num2 = GetPlayerAttackDamageByLevel(this.playerLevel);
            return (this.GetTotalHeroDamage() * this.GetBonusType(BonusType.AllDamage) * this.getDamageArtifact()) + (num2 * 15);
        }

        public double GetUpgradeCostByLevel(int iLevel)
        {
            double num = (double)Math.Min(25, 3 + iLevel) * Math.Pow(1.074, (double)iLevel);
            double a = num * (1.0 - this.GetBonusType(BonusType.UpgradeCost));
            return Math.Ceiling(a);
        }

        private double GetPlayerAttackDamageByLevel(int iLevel)
        {
            double num = (double)iLevel * Math.Pow(1.05, (double)iLevel);
            double statBonus = this.GetBonusType(BonusType.AllDamage);
            double statBonus2 = this.GetBonusType(BonusType.PlayerDamage);
            double num2 = this.GetBonusType(BonusType.PlayerDamageDPS) * this.GetTotalHeroDamage();
            double artifactDamageBonus = getDamageArtifact();
            double num3 = (num * (1.0 + statBonus) + num2) * (1.0 + statBonus2) * (1.0 + artifactDamageBonus);
            if (num3 <= 1.0)
            {
                num3 = 1.0;
            }
            return num3;
        }
    
        public double GetStageBaseHP()
        {
            return 18.5 * Math.Pow(1.57, (double)Math.Min((float)this.stage, 156)) * Math.Pow(1.17, (double)Math.Max((float)this.stage - 156, 0f));
        }
        public double GetStageBaseGold()
        {
            double stageBaseHP = this.GetStageBaseHP();
            double num = stageBaseHP * (double)(0.02 + 0.00045 * Math.Min((float)this.stage, 150));
            return Math.Round(num * Math.Ceiling(1.0 + this.GetBonusType(BonusType.AllGold)));
        }
        public double GetTreasureSpawnChance()
        {
            return 0.021f * (1f + this.GetBonusType(BonusType.ChestChance));
        }

        public double GetTreasureGold()
        {
            return Math.Round(this.GetStageBaseGold() * 10 * (1f + this.GetBonusType(BonusType.ChestGold)));
        }
        
        public void StartStage()
        {
            stage++;
            Double randomNumber = Ramdom.NextDouble();
            if (GetTreasureSpawnChance() > randomNumber)
                this.currentStage = new stage(GetStageBaseHP(), GetStageBaseGold(), true);
            else
                this.currentStage = new stage(GetStageBaseHP(), GetStageBaseGold(), true);
        }

        public void Attack(int timesPerSecond)
        {
            this.currentStage.CurrentHP -= (this.GetTotalDps()/timesPerSecond);
            if (this.currentStage.CurrentHP <= 0)
            {
                if (this.currentStage.Kills < 10)
                {
                    this.currentStage.CurrentHP = currentStage.MaxHP;
                    this.currentStage.Kills++;
                    this.gold += this.currentStage.Prize;
                }
                else
                {
                    this.gold += this.currentStage.Prize;
                    StartStage();
                }
            }
        }

        public double GetHeroLevelPrestigeRelics()
        {
            int num = 0;
            foreach (var unit in this.Units)
            {
                num += unit.heroLevel;
            }
            double num2 = (double)num / (double)500;
            num2 *= 1.0 + this.GetBonusType(BonusType.BonusRelic);
            num2 = Math.Ceiling(num2);
            return num2;
        }

        public double GetUnlockedStagePrestigeRelics()
        {
            double num = 0.0;
            int unlockedStage = this.stage;
            num += Math.Pow((double)(this.stage / 15), 1.7);
            num *= 1.0 + this.GetBonusType(BonusType.BonusRelic);
            return Math.Ceiling(num);
        }
        public double GetPrestigeRelicCount()
        {
            double num = (double)Math.Round((float)this.GetHeroLevelPrestigeRelics());
            num += (double)Math.Round((float)this.GetUnlockedStagePrestigeRelics());
            return 2.0 * num;
        }
        public void Prestige()
        {
            foreach (var unit in Units)
            {
                unit.heroLevel = 0;
                foreach (var skill in unit.heroSkills)
                    skill.isUnlocked = false;
                this.gold = 0;
                this.stage = 0;
                this.honor += GetPrestigeRelicCount();
                StartStage();
            }
        }
    }
}

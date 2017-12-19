using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleGame
{
    public class Gear
    {
        public GearID GearID;
        public int level;
        public int maxLevel;
        public BonusType bonusType;
        public float bonusPerLevel;
        public BonusType bonusType2;
        public float bonusPerLevel2;
        public float damageBonusBase;
        public float costCoef = 0.7f;
        public float costExpo = 1.5f;
        public bool unlocked;
        public string name;
        public Gear(GearID GearID, string name, int maxLevel, BonusType bonusType2, float bonusPerLevel2, float damageBonusBase, float bonusPerLevel)
        {
            this.GearID = GearID;
            this.name = name;
            this.maxLevel = maxLevel;
            this.bonusType = BonusType.AllDamageGear;
            this.bonusPerLevel = bonusPerLevel;
            this.bonusType2 = bonusType2;
            this.bonusPerLevel2 = bonusPerLevel2;
            this.damageBonusBase = damageBonusBase;
            this.unlocked = false;
            this.level = 1;
        }

        public double LevelUpCost()
        {
            return Math.Round((double)this.costCoef * Math.Pow((double)(this.level + 1), (double)this.costExpo));
        }

        public BonusType GetbonusType()
        {
            return this.bonusType2;
        }

        public float GetDamageBonus()
        {
            return this.damageBonusBase + this.bonusPerLevel * (this.level - 1);
        }

        public float GetBonusMagnitude()
        {
            return bonusPerLevel2 * this.level;
        }

        public void UpgradeGear()
        {
            this.level++;
        }

    }
}

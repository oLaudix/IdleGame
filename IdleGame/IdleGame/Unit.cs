using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleGame
{
    public class Unit
    {
        private float purchaseCost;
        public List<UnitSkill> heroSkills;
        public float currentDPS;
        public float currentDamage;
        public float currentCoolDown;
        public float nextUpgradeCost;
        public float nextLevelDPSDiff;
        //public SkillInfo nextToBeBoughtSkill;
        public float nextToBeBoughtSkillCost;
        private float currentPassiveThisHeroDamage;
        public int heroID;
        public string name;
        double costMultiplier;
        double attackDamage;
        public int heroLevel;

        public Unit(int heroID, string name, float costMultiplier, float purchaseCost)
        {
            this.heroSkills = new List<UnitSkill>();
            this.heroID = heroID;
            this.name = name;
            this.costMultiplier = costMultiplier;
            //this.attackDamage = attackDamage;
            this.purchaseCost = purchaseCost;
            this.heroLevel = 0;
            //this.nextToBeBoughtSkill = null;
        }

        public bool IsEvolved()
        {
            return this.heroLevel >= 1001;
        }

        public bool IsEvolved(int iLevel)
        {
            return iLevel >= 1001;
        }

        public void UpgradeHero(int iLevels = 1)
        {
            if (!this.IsEvolved() && this.heroLevel + iLevels >= 1001)
               {
                   //this.EvolveHero(false);
               }
               this.heroLevel += iLevels;
               //this.UpdateNextToBeBoughtSkill();
               this.UpdateHeroStats(true);
        }

        public void UpdateHeroStats(bool iNeedToCallDelegate = true)
        {
            this.currentDPS = this.GetDPSByLevel(this.heroLevel);
            this.nextLevelDPSDiff = this.GetDPSByLevel(this.heroLevel + 1) - this.currentDPS;
            this.nextUpgradeCost = this.GetUpgradeCostByLevel(this.heroLevel);
        }

        public float GetDPSByLevel(int iLevel)
        {
            float num2;
            if (this.IsEvolved(iLevel))
            {
                num2 = (float)Math.Pow((double)0.904f, (double)(iLevel - 1001)) * (float)Math.Pow((double)(1f - 0.019f * 15f), (double)(this.heroID + 33));
            }
            else
            {
                num2 = (float)Math.Pow((double)0.904f, (double)(iLevel - 1)) * (float)Math.Pow((double)(1f - 0.019f * Math.Min((float)this.heroID, 15f)), (double)this.heroID);
            }
            //Console.WriteLine(this.GetBaseUpgradeCostByLevel(iLevel - 1));
            if (num2 < 1E-308F)
            {
                num2 = 1E-308F;
            }
            float num3;
            if (this.IsEvolved(iLevel))
            {
                num3 = num2 * 0.1f * this.GetBaseUpgradeCostByLevel(iLevel - 1) * (float)(Math.Pow((double)1.075f, (double)(iLevel - (1001 - 1))) - 1.0) / (1.075f - 1f);
            }
            else
            {
                num3 = num2 * 0.1f * this.GetBaseUpgradeCostByLevel(iLevel - 1) * (float)(Math.Pow((double)1.075f, (double)iLevel) - 1.0) / (1.075f - 1f);
            }
            return num3 * (1.0f + this.GetHeroPassive());
        }
        
        public float GetHeroPassive()
        {
            float num = 0f;
            foreach (var skill in this.heroSkills)
            {
                if (skill.isUnlocked)
                {
                    if (skill.bonusType == BonusType.HeroDamage)
                    {
                        num += skill.magnitude;
                    }
                }
            }
            return num;
        }

        private float GetBaseUpgradeCostByLevel(int iLevel)
        {
            return this.GetHeroBaseCost(iLevel) * (float)Math.Pow((double)1.075f, (double)iLevel);
        }

        private float GetHeroBaseCost(int iLevel = -1)
        {
            float num = this.purchaseCost;
            if (iLevel == -1)
            {
                iLevel = this.heroLevel;
            }
            if (iLevel >= 1001 - 1)
            {
                num *= 10f;
            }
            return num;
        }

        public float GetUpgradeCostByLevel(int iLevel)
        {
            float baseUpgradeCostByLevel = this.GetBaseUpgradeCostByLevel(iLevel);
            float a = baseUpgradeCostByLevel; //* (1.0 + PlayerModel.instance.GetStatBonus(BonusType.AllUpgradeCost));
            return (float)Math.Ceiling(a);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleGame
{
    public class Unit
    {
        private double purchaseCost;
        public List<UnitSkill> heroSkills;
        public double currentDPS;
        public double currentDamage;
        public double currentCoolDown;
        public double nextUpgradeCost;
        public double nextLevelDPSDiff;
        //public SkillInfo nextToBeBoughtSkill;
        public double nextToBeBoughtSkillCost;
        public int heroID;
        public string name;
        double costMultiplier;
        public int heroLevel;

        public Unit(int heroID, string name, double costMultiplier, double purchaseCost)
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

        public double GetDPSByLevel(int iLevel)
        {
            double num2;
            if (this.IsEvolved())
            {
                num2 = (double)Math.Pow((double)0.904f, (double)(iLevel - 1001)) * (double)Math.Pow((double)(1f - 0.019f * 15f), (double)(this.heroID + 33));
            }
            else
            {
                num2 = (double)Math.Pow((double)0.904f, (double)(iLevel - 1)) * (double)Math.Pow((double)(1f - 0.019f * Math.Min((double)this.heroID, 15f)), (double)this.heroID);
            }
            double num3;
            if (this.IsEvolved())
            {
                num3 = num2 * 0.1f * this.GetBaseUpgradeCostByLevel(iLevel - 1) * (double)(Math.Pow((double)1.075f, (double)(iLevel - (1001 - 1))) - 1.0) / (1.075f - 1f);
            }
            else
            {
                num3 = num2 * 0.1f * this.GetBaseUpgradeCostByLevel(iLevel - 1) * (double)(Math.Pow((double)1.075f, (double)iLevel) - 1.0) / (1.075f - 1f);
            }
            return num3 * (1.0f + this.GetHeroPassive());
        }
        
        public double GetHeroPassive()
        {
            double num = 0f;
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

        private double GetBaseUpgradeCostByLevel(int iLevel)
        {
            return this.GetHeroBaseCost(iLevel) * (double)Math.Pow((double)1.075f, (double)iLevel);
        }

        private double GetHeroBaseCost(int iLevel = -1)
        {
            double num = this.purchaseCost;
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

        public double GetUpgradeCostByLevel(int iLevel)
        {
            double baseUpgradeCostByLevel = this.GetBaseUpgradeCostByLevel(iLevel);
            double a = baseUpgradeCostByLevel; //* (1.0 + PlayerModel.instance.GetStatBonus(BonusType.AllUpgradeCost));
            return (double)Math.Ceiling(a);
        }
    }
}

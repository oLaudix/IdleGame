using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleGame
{
    public class UnitSkill
    {
        public string description;
        public float unlockCost;
        public float magnitude;
        public int requiredLevel;
        public bool isUnlocked;
        public BonusType bonusType;
        public UnitSkill(BonusType bonusType, float magnitude, int requiredLevel, float unlockCost)
        {
            this.isUnlocked = false;
            //this.description = description;
            this.bonusType = bonusType;
            this.magnitude = magnitude;
            this.requiredLevel = requiredLevel;
            this.unlockCost = unlockCost;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleGame
{
    public class stage
    {
        public Double MaxHP;
        public Double CurrentHP;
        public int Kills;
        public Double Prize;
        public bool Chest;
        public stage(Double MaxHP, Double Prize, bool Chest)
        {
            this.MaxHP = MaxHP;
            this.Prize = Prize;
            this.CurrentHP = MaxHP;
            this.Kills = 0;
            this.Chest = Chest;
        }
    }
}

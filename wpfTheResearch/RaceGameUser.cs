using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class RaceGameUser
    {
        private int moneyInGame=1000;
        private int moneyBet;

        public RaceGameUser()
        {
            
        }
        public int MoneyBet
        {
            get { return this.moneyBet; }
            set { this.moneyBet = value; }
        }
        public int MoneyInGame
        {
            get { return this.moneyInGame; }
            set { this.moneyInGame = value; }
        }
        public void win()
        {
            this.moneyInGame += this.moneyBet * 2;
        }
        public void lose()
        {
            this.moneyInGame = this.moneyInGame - this.moneyBet;
        }
    }
}

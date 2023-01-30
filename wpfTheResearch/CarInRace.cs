using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfViewModelTheResearch;

namespace ModelTheResearch
{
    public class CarInRace
    {
        private FormulaCar car;
        private Formula1Race race;

        public CarInRace(FormulaCar car, Formula1Race race)
        {
            this.car = car;
            this.race = race;
        }

        public FormulaCar Car
        {
            get { return car; }
        }
        public Formula1Race Formula1Race
        {
            get { return race; }
        }
    }
}

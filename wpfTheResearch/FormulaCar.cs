using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class FormulaCar
    {
        private double speed;
        private string color;
        private Driver driver;
        //the speed is in meters/seconds
        private double maxSpeed=200.0; 
        private double mixSpeed = 20.0; 

        public FormulaCar(string color)
        {
            this.speed = 0;
            this.color = color;
        }
        public FormulaCar(string color, Driver driver)
        {
            this.speed = 0;
            this.color = color;
            this.driver = driver;
        }
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }  
        }
        public  Driver Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        public double MaxSpeed
        {
            get { return maxSpeed; }
        }
        public double MixSpeed
        {
            get { return mixSpeed; }
        }
    }
}

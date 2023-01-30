using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTheResearch
{
    public class Formula1Race
    {
        //the length is in Meters
        private double length = 30000; //30km
        private  double totalTime;

        public Formula1Race(double totalTime)
        {
            this.totalTime = totalTime;
        }
        public double TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }
        public void AddToTotal(double time)
        {
            this.totalTime += time;
        }
        public double TimeToFinishLap(FormulaCar formulaCar)
        {
            return this.length / formulaCar.Speed;
        }

        public async Task TaskRace1(FormulaCar car1)
        {
            Formula1Race Race1 = new Formula1Race(0);
            CarInRace carInRace1 = new CarInRace(car1, Race1);          
            await Task.Run(() => OneLap(carInRace1));

        }
        public async Task TaskRace2(FormulaCar car2)
        {

            Formula1Race Race2 = new Formula1Race(0);
            CarInRace carInRace2 = new CarInRace(car2, Race2);
            await Task.Run(() => OneLap(carInRace2));
            
        }
        public async Task TaskRace3(FormulaCar car3)
        {

            Formula1Race Race3 = new Formula1Race(0);
            CarInRace carInRace3 = new CarInRace(car3, Race3);
            await Task.Run(() => OneLap(carInRace3));
        }
        private async Task OneLap(CarInRace carInRace)
        {
            Random speed = new Random();
            carInRace.Car.Speed = carInRace.Car.MixSpeed+ (carInRace.Car.MaxSpeed - carInRace.Car.MixSpeed)*speed.NextDouble();
            double TimeRoFinish = TimeToFinishLap(carInRace.Car);

            AddToTotal(TimeRoFinish);
            await Task.Delay((int)TimeRoFinish);


        }
       //     carInRace.Formula1Race.currentLapNumber++;
        //public void currentLeader(CarInRace CarRace1, CarInRace CarRace2, CarInRace CarRace3)
        //{

        //    List<CarInRace> laps = new List<CarInRace>();
        //    laps.Add(CarRace1);
        //    laps.Add(CarRace2);
        //    laps.Add(CarRace3);

        //    laps = laps.OrderByDescending(x => x.Formula1Race.CurrentLaNumber).ToList();
        //    //find the leading car and color it (the leader is in laps[0])
        //    currentLeaderName = laps[0].Car.Driver.Name;

        //}
    }
}

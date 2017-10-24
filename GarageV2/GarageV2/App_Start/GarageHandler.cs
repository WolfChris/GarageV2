using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarageV2.Models;

namespace GarageV2.App_Start
{
    class GarageHandler
    {
        static Garage<ParkedVehicle> g;
        public static Garage<ParkedVehicle> CreateGarage(int capacity)
        {
            g = new Garage<ParkedVehicle>(capacity);
            return g;
        }

        public static bool AddVehicle(ParkedVehicle v)
        {
            bool canPark = g.AddVehicle(v);
            return canPark;
        }
        public static bool RemoveVehicle(string regno)
        {
            var vehicle = g.FirstOrDefault(v => v.RegNo == regno);
            bool canUnpark = g.RemoveVehicle(vehicle);
            return canUnpark;
        }
        public static bool FindVehicle(string regno)
        {
            var vehicle = g.FirstOrDefault(v => v.RegNo == regno);
            Console.WriteLine(vehicle.ToString());
            return true;
        }
    }
}
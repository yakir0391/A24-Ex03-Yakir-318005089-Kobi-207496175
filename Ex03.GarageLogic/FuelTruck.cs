using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelTruck : Truck
    {
        FuelSystem fuelSystem = new FuelSystem();
        VehicleInGarage vehicleInGarage = new VehicleInGarage();
    }
}

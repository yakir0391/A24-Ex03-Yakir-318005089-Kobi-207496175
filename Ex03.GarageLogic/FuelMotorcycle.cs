﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private FuelSystem fuelSystem = new FuelSystem(); 
        private VehicleInGarage vehicleInGarage = new VehicleInGarage();
    }
}

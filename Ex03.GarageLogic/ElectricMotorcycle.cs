﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle: Motorcycle
    {
        ElectricSystem electricSystem = new ElectricSystem();
        VehicleInGarage vehicleInGarage = new VehicleInGarage();
    }
}

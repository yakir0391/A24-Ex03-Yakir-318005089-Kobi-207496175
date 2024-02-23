using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        ElectricSystem electricSystem = new ElectricSystem();
        VehicleInGarage vehicleInGarage = new VehicleInGarage();

        public void UpdateElectricCarDetails(eCarColors i_Color, eNumberOfDoors i_NumberOfDoors ,string i_ModelName
            , string i_LicenceNumber, float i_EnergyLeft, List<Wheel> i_Wheels)
        {
            this.UpdateCarDetails(i_Color, i_NumberOfDoors);
            this.UpdateVehicleDetails(i_ModelName, i_LicenceNumber, i_EnergyLeft, i_Wheels);
        }
    }
}

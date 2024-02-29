using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        private string[] m_VehicleTypes = { "Fuel Car", "Fuel Motorcycle", "Electric Car", "Electric Motorcycle", "Fuel Truck" };

        public string[] VehicleTypes
        {
            get { return m_VehicleTypes; }
        }

        public Vehicle CreateVehicle(int i_UserChoice)
        {
            Vehicle chosenVehicle = null;

            switch (i_UserChoice)
            {
                case 0:
                    chosenVehicle = new FuelCar();
                    break;
                case 1:
                    chosenVehicle = new FuelMotorcycle();
                    break;
                case 2:
                    chosenVehicle = new ElectricCar();
                    break;
                case 3:
                    chosenVehicle = new ElectricMotorcycle();
                    break;
                case 4:
                    chosenVehicle = new FuelTruck();
                    break;
                default:
                    break;
            }

            return chosenVehicle;
        }
    }
}

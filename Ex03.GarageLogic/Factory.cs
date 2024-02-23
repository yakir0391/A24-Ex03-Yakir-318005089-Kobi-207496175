using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        public Vehicle CreateVehicle(int userChoice)
        {
            Vehicle chosenVehicle = null;

            switch (userChoice)
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

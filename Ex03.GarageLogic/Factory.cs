using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        private string[] m_VehicleTypes = { "FuelCar", "FuelMotorcycle", "ElectricCar", "ElectricMotorcycle", "FuelTruck" };

        public string[] VehicleTypes
        {
            get { return m_VehicleTypes; }
        }

        public FuelCar CreateFuelCar()
        {
            return new FuelCar(30,5) ;
        }
        public FuelMotorcycle CreateFuelMotorcycle()
        {
            return new FuelMotorcycle(29,2);
        }

        public ElectricCar createElectricCar()
        {
            return new ElectricCar(30,5);
        }
        public ElectricMotorcycle createElectricMotorcycle() 
        {
            return new ElectricMotorcycle(29,2) ;
        }
        public FuelTruck createFuelTruck()
        {
            return new FuelTruck(28, 12);
        }
/*        public Vehicle CreateVehicle(int userChoice)
        {
            Vehicle chosenVehicle = null;

            switch (userChoice)
            {
                case 0:
                    ((FuelCar)chosenVehicle).SetMaxAirPressureAndAmountOfWheels(30, 5);


                    break;
                case 1:
                    chosenVehicle = new FuelMotorcycle();
                    chosenVehicle.SetMaxAirPressureAndAmountOfWheels(29, 2);
                    ((FuelMotorcycle)chosenVehicle).FuelSystem.SetFuelType(eFuelType.OCTAN98);
                    ((FuelMotorcycle)chosenVehicle).FuelSystem.SetMaxFuelQuantity(58);
                    break;
                case 2:
                    chosenVehicle = new ElectricCar();
                    chosenVehicle.SetMaxAirPressureAndAmountOfWheels(30, 5);
                    ((ElectricCar)chosenVehicle).ElectricSystem.SetBatteryLife(4.8f);
                    break;
                case 3:
                    chosenVehicle = new ElectricMotorcycle();
                    chosenVehicle.SetMaxAirPressureAndAmountOfWheels(30, 5);
                    ((ElectricMotorcycle)chosenVehicle).ElectricSystem.SetBatteryLife(2.8f);
                    break;
                case 4:
                    chosenVehicle = new FuelTruck();
                    chosenVehicle.SetMaxAirPressureAndAmountOfWheels(28, 12);
                    ((FuelTruck)chosenVehicle).FuelSystem.SetFuelType(eFuelType.Soler);
                    ((FuelTruck)chosenVehicle).FuelSystem.SetMaxFuelQuantity(110);
                    break;
                default:
                    break;
            }

            return chosenVehicle;
        }*/
    }
}

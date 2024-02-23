using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        private static Factory m_vehiclesFactory = new Factory();

        public static void Main()
        {
            ChooseMenu();
        }

        public static void ChooseMenu()
        {
            string menu = $"Please choose what action you wish to do :" +
                $"1 : Enter new vehicle in garage." +
                $"2 : Display the licence numbers of vehicles in the garage." +
                $"3 : Change a vehicle condition in the garage." +
                $"4 : Inflate vehicle's wheels to maximum." +
                $"5 : Refuel a vehicle in the garage." +
                $"6 : Charge electric vehicle." +
                $"7 : Display data of a specific car according to licence number.";
            Console.WriteLine(menu);

            string strChoice = Console.ReadLine();
            int.TryParse(strChoice, out int choice);

            switch (choice)
            {
                case 1:
                    EnterNewVehicleInGarage();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                default:
                    break;
            }
        }
     
        public static void EnterNewVehicleInGarage()
        {
            Vehicle chosenVehicle;
            string vehicle;
            string menu = $"Please choose which vehicle you wish to enter the garage: \n" +
                          $"0 : Fuel Car\n" +
                          $"1 : Fuel Motorcycle\n" +
                          $"2 : Electric Car\n" +
                          $"3 : Electric Motorcycle\n" +
                          $"4 : Truck";

            Console.WriteLine(menu);
            vehicle = Console.ReadLine();
            int.TryParse(vehicle , out int result);
            chosenVehicle = m_vehiclesFactory.CreateVehicle(result);

            
        }
    }
}

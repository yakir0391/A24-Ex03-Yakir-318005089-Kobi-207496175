using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace sol
{
    internal class Class1
    {
        public static void Main(string[] args)
        {
            // Example: Create an instance of Car and populate its fields
            Vehicle chosenVehicle = new FuelCar();
            ((FuelCar)chosenVehicle).SetMaxAirPressureAndAmountOfWheels(30, 5);
            ((FuelCar)chosenVehicle).FuelSystem.SetFuelType(eFuelType.OCTAN95);
            ((FuelCar)chosenVehicle).FuelSystem.SetMaxFuelQuantity(58);

            FuelCar fuelCar = CheckAndDowncastVehicleType<FuelCar>(chosenVehicle);

            GetFuelSystemInfoFromUser(fuelCar.FuelSystem);
            GetCarInfoFromUser(fuelCar);
            GetCarInfoFromUser(fuelCar);
            while (true)
            { }

            // Now the car object has been populated with user input data
        }
        public static void GetCarInfoFromUser(Car i_ChosenVehicle)
        {
            string colorSelected, numOfDoorsSelected;
            int parsedColorSelected, parsedNumOfDoors;
            eCarColors eColor;
            eNumberOfDoors eNumberOfDoors;

            while (true)
            {
                try
                {
                    Console.WriteLine("Select the color of your car \nCar Colors Menu:");
                    foreach (eCarColors color in Enum.GetValues(typeof(eCarColors)))
                    {
                        Console.WriteLine($"{(int)color} : {color}");
                    }

                    colorSelected = Console.ReadLine();

                    if (!int.TryParse(colorSelected, out parsedColorSelected))
                    {
                        throw new FormatException("Please enter a valid number.");
                    }
                    else
                    {
                        if (parsedColorSelected < 0 || parsedColorSelected > 3)
                        {
                            throw new ValueOutOfRangeException("Color selection should be between 0-3!.", 0, 3);
                        }

                        eColor = (eCarColors)Enum.GetValues(typeof(eCarColors)).GetValue(parsedColorSelected);
                        break;
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Please choose the number of doors:");
                    foreach (eNumberOfDoors numberOfDoors in Enum.GetValues(typeof(eNumberOfDoors)))
                    {
                        Console.WriteLine($"{(int)numberOfDoors}: {numberOfDoors}");
                    }

                    numOfDoorsSelected = Console.ReadLine();

                    if (!int.TryParse(numOfDoorsSelected, out parsedNumOfDoors))
                    {
                        throw new FormatException("Enter a valid number");
                    }
                    else if (parsedNumOfDoors < 0 || parsedNumOfDoors > 3)
                    {
                        throw new ValueOutOfRangeException("Num of doors selection should be between 0-3!.", 0, 3);
                    }

                    eNumberOfDoors = (eNumberOfDoors)Enum.GetValues(typeof(eNumberOfDoors)).GetValue(parsedNumOfDoors);
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

         
                i_ChosenVehicle.Color = eColor;
                i_ChosenVehicle.NumberOfDoors = eNumberOfDoors;
            

        }
        public static T CheckAndDowncastVehicleType<T>(Vehicle chosenVehicle) where T : Vehicle
        {
            T downcastedVehicle = null;

            if (chosenVehicle is T)
            {
                downcastedVehicle = (T)chosenVehicle;
            }
            else
            {
                // Handle the case where the vehicle type is unknown or not supported
                Console.WriteLine("Unknown vehicle type.");
            }

            return downcastedVehicle;
        }
        public static void GetFuelSystemInfoFromUser(FuelSystem i_ChosenVehicle)
        {
            float parsedCurrentFuelQuantity = 0, maxFuelQuentity = i_ChosenVehicle.MaxFuelQuantity;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the current fuel quantity :");
                    if (!float.TryParse(Console.ReadLine(), out parsedCurrentFuelQuantity))
                    {
                        throw new FormatException("Enter valid input");
                    }
                    if (parsedCurrentFuelQuantity > maxFuelQuentity)
                    {
                        throw new ValueOutOfRangeException("The current fuel quantity is over the maximum", 0, maxFuelQuentity);
                    }

                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
                i_ChosenVehicle.CurrentFuelQuantity = parsedCurrentFuelQuantity; 
        }
        public static void CheckAndDowncassttVehicleType(ref Vehicle chosenVehicle)
        {
            if (chosenVehicle is FuelCar)
            {
                FuelCar fuelCar = (FuelCar)chosenVehicle;
                // Now you can work with fuelCar as a FuelCar
            }
            else if (chosenVehicle is ElectricCar)
            {
                ElectricCar electricCar = (ElectricCar)chosenVehicle;
                // Now you can work with electricCar as an ElectricCar
            }
            else if (chosenVehicle is FuelMotorcycle)
            {
                FuelMotorcycle fuelMotorcycle = (FuelMotorcycle)chosenVehicle;
                // Now you can work with fuelMotorcycle as a FuelMotorcycle
            }
            else if (chosenVehicle is ElectricMotorcycle)
            {
                ElectricMotorcycle electricMotorcycle = (ElectricMotorcycle)chosenVehicle;
                // Now you can work with electricMotorcycle as an ElectricMotorcycle
            }
            else if (chosenVehicle is FuelTruck)
            {
                FuelTruck fuelTruck = (FuelTruck)chosenVehicle;
                // Now you can work with fuelTruck as a FuelTruck
            }
            else
            {
                // Handle the case where the vehicle type is unknown or not supported
                Console.WriteLine("Unknown vehicle type.");
            }
        }
        public static void PopulateFieldsFromUserInput<T>(T obj)
        {
            // Get the type of the object
            Type type = typeof(T);
            FieldInfo[] arr = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            // Iterate through the fields of the type
            foreach (FieldInfo field in arr)
            {
                if(field.Name=="m_FuelSystem")
                {
                    //GetValuesForFuelSystem();
                    continue;
                }
                // Prompt the user for input based on the field name
                Console.Write($"Enter value for {field.Name}: ");
                string userInput = Console.ReadLine();

                // Convert the user input to the appropriate field type and set the field value
                object value = Convert.ChangeType(userInput, field.FieldType);
                field.SetValue(obj, value);
            }
        }
    }
  
}

using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        private static Factory m_VehiclesFactory = new Factory();
        private static Garage m_Garage = new Garage();

        public static void Main()
        {
            ChooseMenu();
        }

        public static void ChooseMenu()
        {
            while (true)
            {
                string menu = $"Please choose what action you wish to do :\n" +
                    $"1 : Enter new vehicle in garage.\n" +
                    $"2 : Display the licence numbers of vehicles in the garage.\n" +
                    $"3 : Change a vehicle condition in the garage.\n" +
                    $"4 : Inflate vehicle's wheels to maximum.\n" +
                    $"5 : Refuel a vehicle in the garage.\n" +
                    $"6 : Charge electric vehicle.\n" +
                    $"7 : Display data of a specific car according to licence number.\n" +
                    "Any other key to Exit";
                Console.WriteLine(menu);

                string strChoice = Console.ReadLine();
                int.TryParse(strChoice, out int choice);

                switch (choice)
                {
                    case 1:
                        EnterNewVehicleInGarage();
                        break;
                    case 2:
                        DisplayLicenceNumbers();
                        break;
                    case 3:
                        ChangeVehicleCondition();
                        break;
                    case 4:
                        InflateTiresToMax();
                        break;
                    case 5:
                        RefuelVehicle();
                        break;
                    case 6:
                        RechargeVehicle();
                        break;
                    case 7:
                        DisplaySpecificCarDetails();
                        break;
                    default:
                        Console.WriteLine("Bye Bye");
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine("Press any key to return home page.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void EnterNewVehicleInGarage()
        {
            int chosenVehicleID;
            string licenceNumber;
            Vehicle chosenVehicle;
            Dictionary<string, Type> getParametersDict = new Dictionary<string, Type>();
            Dictionary<string, object> setParametersDict = new Dictionary<string, object>();
            VehicleInGarageInformation client = new VehicleInGarageInformation();

            licenceNumber = UserEnterLicenseNumber();
            setParametersDict.Add("Licence number", licenceNumber);

            if (!m_Garage.CheckIfLicenseNumberExist(licenceNumber))
            {
                chosenVehicleID = UserSelectVehicleForGarage();
                GetClientInfo(client);
                chosenVehicle = m_VehiclesFactory.CreateVehicle(chosenVehicleID);
                chosenVehicle.GetParameters(getParametersDict);

                while (true)
                {
                    try
                    {
                        foreach (KeyValuePair<string, Type> keyValuePair in getParametersDict)
                        {

                            if (keyValuePair.Value == typeof(bool))
                            {
                                Console.WriteLine($"Press 'yes' or any other key if not {keyValuePair.Key}: ");
                                string boolInput = Console.ReadLine().ToLower();
                                Console.WriteLine("-----------------------------------");
                                bool boolValue = boolInput == "yes";
                                setParametersDict[keyValuePair.Key] = boolValue;
                            }
                            else if (keyValuePair.Value.IsEnum)
                            {
                                setParametersDict[keyValuePair.Key] = HandleEnumSelection(keyValuePair.Value, keyValuePair.Key);
                            }
                            else
                            {
                                Console.Write($"Enter {keyValuePair.Key}: ");
                                string inputValue = Console.ReadLine();

                                object convertedValue = Convert.ChangeType(inputValue, keyValuePair.Value);
                                setParametersDict[keyValuePair.Key] = convertedValue;
                                Console.WriteLine("-----------------------------------");
                            }
                        }

                        chosenVehicle.SetParameters(setParametersDict);
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("value not valid !");
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("\nClient info saved.\nPlease fill the car parameters once againg.\n");
                    }
                }

                m_Garage.Vehicles.Add(licenceNumber, (chosenVehicle, client));
            }
            else
            {
                Console.WriteLine("Vehicle already exist in garage!\n");
                Console.WriteLine("----------------------------------");
                m_Garage.Vehicles[licenceNumber].Item2.VehicleCondition = eVehicleCondition.UnderRepair;
            }
        }

        public static object HandleEnumSelection(Type i_EnumType, string i_EnumName)
        {
            int selectedOption, countEnumOptions = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine($"Select an option for {i_EnumName}: ");
                    foreach (var value in Enum.GetValues(i_EnumType))
                    {
                        countEnumOptions++;
                        Console.WriteLine($"{(int)value}. {value}");
                    }

                    Console.Write("Enter your selection: ");

                    if (!int.TryParse(Console.ReadLine(), out selectedOption))
                    {
                        throw new FormatException("Enter a valid number");
                    }
                    else if (!Enum.IsDefined(i_EnumType, selectedOption))
                    {
                        throw new ValueOutOfRangeException("Value out of range", 0, countEnumOptions);
                    }

                    Console.WriteLine("--------------------------");
                    return Enum.ToObject(i_EnumType, selectedOption);

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
        }

        public static string UserEnterLicenseNumber()
        {
            string licenceNumber;

            Console.Write("Please enter the license number: ");
            licenceNumber = Console.ReadLine();
            Console.WriteLine("--------------------------");

            return licenceNumber;
        }

        public static int UserSelectVehicleForGarage()
        {
            string vehicle;
            int parsedVehicleId;

            while (true)
            {
                try
                {
                    Console.WriteLine("\nPlease choose which vehicle you wish to enter the garage: ");

                    for (int i = 0; i < m_VehiclesFactory.VehicleTypes.Length; i++)
                    {
                        Console.WriteLine("{0} : {1}", i, m_VehiclesFactory.VehicleTypes[i]);
                    }

                    vehicle = Console.ReadLine();
                    Console.WriteLine("\n--------------------------");

                    if (!int.TryParse(vehicle, out parsedVehicleId))
                    {
                        throw new FormatException("Please enter a valid number.");
                    }
                    else
                    {
                        if (parsedVehicleId < 0 || parsedVehicleId > 4)
                        {
                            throw new ValueOutOfRangeException("Vehicle ID must be between 0 and 4.", 0, 4);
                        }
                        break;
                    }
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

            return parsedVehicleId;
        }

        public static void GetClientInfo(VehicleInGarageInformation i_Client)
        {
            string ownerName, ownerPhoneNumber;

            Console.Write("Enter your name: ");
            ownerName = Console.ReadLine();
            Console.WriteLine("--------------------------");
            Console.Write("Enter your phone number: ");
            ownerPhoneNumber = Console.ReadLine();
            Console.WriteLine("--------------------------");
            object carCondition = HandleEnumSelection(typeof(eVehicleCondition), "Vehicle condition");

            i_Client.OwnerName = ownerName;
            i_Client.OwnerPhoneNumber = ownerPhoneNumber;
            i_Client.VehicleCondition = (eVehicleCondition)carCondition;
        }

        public static void DisplayLicenceNumbers()
        {
            object chosenConditionToFilter;
            string isFilter;
            int count = 1;
            List<string> filteredLicence = new List<string>();
            eVehicleCondition condition = eVehicleCondition.UnderRepair;

            Console.WriteLine("Press 1 if you wish to filter by their condition , press any other key otherwise.");
            isFilter = Console.ReadLine();

            if (isFilter != "1")
            {
                filteredLicence = m_Garage.GetLicenceArray(isFilter, condition);
            }
            else
            {
                chosenConditionToFilter = HandleEnumSelection(typeof(eVehicleCondition), "Vehicle condition");
                filteredLicence = m_Garage.GetLicenceArray(isFilter, (eVehicleCondition)chosenConditionToFilter);

            }

            Console.WriteLine("===========================================");
            Console.WriteLine("Licence Numbers");
            Console.WriteLine("===========================================");

            foreach (string licence in filteredLicence)
            {
                Console.WriteLine($"{count}. {licence}");
                count++;
            }

            Console.WriteLine("===========================================");
        }
        public static void ChangeVehicleCondition()
        {
            Console.Write("Enter the license number of the vehicle:");
            string licenseNumber = Console.ReadLine();
            object newStatus;

            if (m_Garage.CheckIfLicenseNumberExist(licenseNumber))
            {
                newStatus = HandleEnumSelection(typeof(eVehicleCondition), "Vehicle condition");

                m_Garage.ChangeVehicleStatus(licenseNumber, (eVehicleCondition)newStatus);

                Console.WriteLine($"Status of vehicle with license number {licenseNumber} changed to {newStatus}.");
            }
            else
            {
                Console.WriteLine($"Vehicle with license number {licenseNumber} does not exist in the garage.");
            }
        }

        public static void InflateTiresToMax()
        {
            Vehicle vehicle = null;
            Console.Write("Enter the license number of the vehicle:");
            string licenseNumber = Console.ReadLine();

            if (m_Garage.CheckIfLicenseNumberExist(licenseNumber))
            {
                vehicle = m_Garage.Vehicles[licenseNumber].Item1;
                vehicle.InflateAir();
                Console.WriteLine($"Infalted all vehicle wheels with license number {licenseNumber} to maximum.");
            }
            else
            {
                Console.WriteLine($"Vehicle with license number {licenseNumber} does not exist in the garage.");
            }
        }

        public static void RefuelVehicle()
        {
            Dictionary<string, object> parameterToFillUp = new Dictionary<string, object>();
            string licenceNumber, fuelAmount;
            object fuelType;
            float parsedFuelAmount;

            Console.Write("Enter the license number of the vehicle:");
            licenceNumber = Console.ReadLine();

            if (m_Garage.CheckIfLicenseNumberExist(licenceNumber))
            {
                Type typeOfVehicle = m_Garage.Vehicles[licenceNumber].Item1.CheckVehicleSystem();
                if (typeof(FuelSystem) == typeOfVehicle)
                {
                    fuelType = HandleEnumSelection(typeof(eFuelType), "Fuel type");
                    parameterToFillUp.Add("Fuel type", fuelType);

                    while (true)
                    {
                        Console.WriteLine("Please enter the amount of fuel you want to fill");
                        fuelAmount = Console.ReadLine();

                        try
                        {
                            if (!float.TryParse(fuelAmount, out parsedFuelAmount))
                            {
                                throw new FormatException("Enter a valid number");
                            }

                            parameterToFillUp.Add("Amount of fuel", parsedFuelAmount);
                            break;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    try
                    {
                        m_Garage.Vehicles[licenceNumber].Item1.FillEnergySource(parameterToFillUp);
                        Console.WriteLine($"Vehicle with licence number {licenceNumber} was fueled !\n");
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Vehicle dose not contain fuel system");
                }
            }
            else
            {
                Console.WriteLine("This licence number is unrecognized in the garage");
            }
        }

        public static void RechargeVehicle()
        {
            string licenceNumber, amountToRecharge;
            float parsedAmountToRecharge;
            Dictionary<string, object> parameterToFillUp = new Dictionary<string, object>();

            Console.Write("Enter the license number of the vehicle:");
            licenceNumber = Console.ReadLine();

            if (m_Garage.CheckIfLicenseNumberExist(licenceNumber))
            {
                Type typeOfVehicle = m_Garage.Vehicles[licenceNumber].Item1.CheckVehicleSystem();
                if (typeof(ElectricSystem) == typeOfVehicle)
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Please enter the amount of hours you want to recharge :");
                            amountToRecharge = Console.ReadLine();
                            if (!float.TryParse(amountToRecharge, out parsedAmountToRecharge))
                            {
                                throw new FormatException("Enter a valid number");
                            }

                            parameterToFillUp.Add("Amount of charge", parsedAmountToRecharge);
                            break;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    try
                    {
                        m_Garage.Vehicles[licenceNumber].Item1.FillEnergySource(parameterToFillUp);
                        Console.WriteLine($"Vehicle with licence number {licenceNumber} was charged !");
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Vehicle dose not contain electric system");
                }
            }
            else
            {
                Console.WriteLine("This licence number is unrecognized in the garage");
            }
        }
        public static void DisplaySpecificCarDetails()
        {
            string licenceNumber;
            Dictionary<string, string> displayParameters = new Dictionary<string, string>();

            Console.Write("Enter the license number of the vehicle:");
            licenceNumber = Console.ReadLine();

            if (m_Garage.CheckIfLicenseNumberExist(licenceNumber))
            {
                m_Garage.GetClientParameters(displayParameters, licenceNumber);
                m_Garage.Vehicles[licenceNumber].Item1.GetParmetersToDisplay(displayParameters);
                Console.WriteLine("\n===========================================================\n");
                PrintVehicleDetails(displayParameters);
                Console.WriteLine("\n===========================================================\n");

            }
            else
            {
                Console.WriteLine("Vehicle not found!");
            }
        }
        
        public static void PrintVehicleDetails(Dictionary<string,string> i_DisplayParameters)
        {
            foreach (KeyValuePair<string, string> keyValuePair in i_DisplayParameters)
            {
                Console.WriteLine($"{keyValuePair.Key}{keyValuePair.Value}");
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}
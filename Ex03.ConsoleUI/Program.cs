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
                    $"7 : Display data of a specific car according to licence number.\n";
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
        }

        public static void EnterNewVehicleInGarage()
        {
            FuelCar fuelCar;
            FuelMotorcycle fuelMotorcycle;
            FuelTruck fuelTruck;
            ElectricCar electricCar;
            ElectricMotorcycle electricMotorcycle;
            VehicleInGarageInformation vehicleInGarageInformation = new VehicleInGarageInformation();
            string licenceNumber;
            bool isExist;
            int vehicleID;

            licenceNumber = UserEnterLicenseNumber();
            isExist = m_Garage.CheckIfLicenseNumberExist(licenceNumber);

            if (!isExist)
            {
                vehicleID = UserSelectVehicleForGarage();
                GetClientInfo(vehicleInGarageInformation);

                switch (vehicleID)
                {
                    case 0:
                        fuelCar = m_VehiclesFactory.CreateFuelCar();
                        GetVehicleInfoFromUser(fuelCar, licenceNumber);
                        GetFuelSystemInfoFromUser(fuelCar.FuelSystem);
                        GetCarInfoFromUser(fuelCar);
                        m_Garage.Vehicles.Add(fuelCar.LicenseNumber,(fuelCar, vehicleInGarageInformation));

                        break;
                    case 1:
                        fuelMotorcycle = m_VehiclesFactory.CreateFuelMotorcycle();
                        GetVehicleInfoFromUser(fuelMotorcycle, licenceNumber);
                        GetFuelSystemInfoFromUser(fuelMotorcycle.FuelSystem);
                        GetMotorcycleInfoFromUser(fuelMotorcycle);
                        m_Garage.Vehicles.Add(fuelMotorcycle.LicenseNumber , (fuelMotorcycle, vehicleInGarageInformation));

                        break;
                    case 2:
                        electricCar = m_VehiclesFactory.createElectricCar();
                        GetVehicleInfoFromUser(electricCar, licenceNumber);
                        GetElectricSystemInfoFromUser(electricCar.ElectricSystem);
                        GetCarInfoFromUser(electricCar);
                        m_Garage.Vehicles.Add(electricCar.LicenseNumber, (electricCar, vehicleInGarageInformation   ));

                        break;
                    case 3:
                        electricMotorcycle = m_VehiclesFactory.createElectricMotorcycle();
                        GetVehicleInfoFromUser(electricMotorcycle, licenceNumber);
                        GetElectricSystemInfoFromUser(electricMotorcycle.ElectricSystem);
                        GetMotorcycleInfoFromUser(electricMotorcycle);
                        m_Garage.Vehicles.Add(electricMotorcycle.LicenseNumber, (electricMotorcycle, vehicleInGarageInformation));

                        break;
                    case 4:
                        fuelTruck = m_VehiclesFactory.createFuelTruck();
                        GetVehicleInfoFromUser(fuelTruck, licenceNumber );
                        GetFuelSystemInfoFromUser(fuelTruck.FuelSystem);
                        GetTruckInfoFromUser(fuelTruck);
                        m_Garage.Vehicles.Add(fuelTruck.LicenseNumber, (fuelTruck, vehicleInGarageInformation));

                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("The vehicle is in the garage.\n");

                m_Garage.UpdateStatusForVehicle(licenceNumber);
            }

        }

        public static string UserEnterLicenseNumber()
        {
            string licenceNumber;

            Console.WriteLine("Please enter the car's license number in length of 6-8 contains only digits :");
            licenceNumber = Console.ReadLine();

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
                    Console.WriteLine("\nPlease choose which vehicle you wish to enter the garage: \n");

                    for (int i = 0; i < m_VehiclesFactory.VehicleTypes.Length; i++)
                    {
                        Console.WriteLine("{0} : {1}\n", i, m_VehiclesFactory.VehicleTypes[i]);
                    }

                    vehicle = Console.ReadLine();

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

        public static void GetVehicleInfoFromUser(Vehicle i_ChosenVehicle,string i_LicenseNumber)
        {
            string modelName, insertWheelsSelection;
            int j = 1;

            Console.WriteLine("Enter model name contains only numbers and charcters :");
            modelName = Console.ReadLine();

            Console.Write("Press 1 if you wish to insert the wheels at once , any other key to insert them 1 by 1");
            insertWheelsSelection = Console.ReadLine();

            for (int i = 0; i < i_ChosenVehicle.Wheels.Count; i++)
            {

                if (insertWheelsSelection != "1" || i < 1) 
                {
                    Console.WriteLine($"Enter details for wheel {j++}:");
                    GetWheelParametersFromUser(i_ChosenVehicle.Wheels[i]);
                }
                else if (i < i_ChosenVehicle.Wheels.Count - 1)
                {
                    i_ChosenVehicle.Wheels[i + 1].Assign(i_ChosenVehicle.Wheels[i]);
                }
            }
            i_ChosenVehicle.LicenseNumber = i_LicenseNumber;
            i_ChosenVehicle.ModelName = modelName;
        }

        public static void GetWheelParametersFromUser(Wheel wheel)
        {
            float currentAirPressure;
            string manufacturerName;

            Console.Write("Enter manufacturer name: :");
            manufacturerName = Console.ReadLine();
            wheel.ManufacturerName = manufacturerName;

            while (true)
            {
                try
                {
                    Console.Write("Enter current air pressure contains only numbers :");
                    if(!float.TryParse(Console.ReadLine(), out currentAirPressure))
                    {
                        throw new FormatException("Enter a valid input");
                    }
                    wheel.CurrentAirPressure = currentAirPressure;

                    break;
                }
                catch(ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public static void GetFuelSystemInfoFromUser(FuelSystem i_ChosenVehicleSystem)
        {
            float parsedCurrentFuelQuantity = 0, maxFuelQuentity = i_ChosenVehicleSystem.MaxFuelQuantity;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the current fuel quantity :");
                    if (!float.TryParse(Console.ReadLine(), out parsedCurrentFuelQuantity))
                    {
                        throw new FormatException("Enter valid input");
                    }

                    i_ChosenVehicleSystem.CurrentFuelQuantity = parsedCurrentFuelQuantity;

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
        }

        public static void GetElectricSystemInfoFromUser(ElectricSystem i_ChosenVehicleElectricSystem)
        {
            float parsedRemainingBattery = 0, batteryLife = 0;

            batteryLife = i_ChosenVehicleElectricSystem.BatteryLife;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the current battery remaining quantity :");

                    if (!float.TryParse(Console.ReadLine(), out parsedRemainingBattery))
                    {
                        throw new FormatException("Enter valid input");
                    }

                    i_ChosenVehicleElectricSystem.RemainingBatteryTime = parsedRemainingBattery;

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

        public static void GetMotorcycleInfoFromUser(Motorcycle i_ChosenVehicle)
        {
            string licenceTypeSelected, engineCapacity;
            int parseLicenceTypeSelected, parsedEngineCapacity;
            eLicenceType selectedLicenceType;
          
            while (true)
            {
                try
                {
                    Console.WriteLine("Please choose the Licence type:");
                    foreach (eLicenceType licenceType in Enum.GetValues(typeof(eLicenceType)))
                    {
                        Console.WriteLine($"{(int)licenceType}: {licenceType}");
                    }

                    licenceTypeSelected = Console.ReadLine();

                    if (!int.TryParse(licenceTypeSelected, out parseLicenceTypeSelected))
                    {
                        throw new FormatException("Enter a valid number");
                    }
                    else if (parseLicenceTypeSelected < 0 || parseLicenceTypeSelected > 3)
                    {
                        throw new ValueOutOfRangeException("Licence type selection should be between 0-3!.", 0, 3);
                    }

                    selectedLicenceType = (eLicenceType)Enum.GetValues(typeof(eLicenceType)).GetValue(parseLicenceTypeSelected);
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

            while (true)
            {
                try
                {
                    Console.WriteLine("Please choose the engine capacity:");
                    engineCapacity = Console.ReadLine();

                    if (!int.TryParse(engineCapacity, out parsedEngineCapacity))
                    {
                        throw new FormatException("Enter a valid number");
                    }
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            i_ChosenVehicle.LicenceType = selectedLicenceType;
            i_ChosenVehicle.EngineCapcity = parsedEngineCapacity;
        }

        public static void GetTruckInfoFromUser(Truck i_ChosenVehicle)
        {
            string isTransportHazardousMaterials, cargoVolume;
            float parsedCargoVolume;
            Console.WriteLine("Please press 1 if truck is transport hazardous materials else press any other key");
            isTransportHazardousMaterials = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter cargo volume (0-100) ");
                    cargoVolume = Console.ReadLine();

                    if (!float.TryParse(cargoVolume, out parsedCargoVolume))
                    {
                        throw new FormatException("Enter a valid number");
                    }            
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }   
            }
            i_ChosenVehicle.CargoVolume = parsedCargoVolume;
            i_ChosenVehicle.IsTransportHazardousMaterials = (isTransportHazardousMaterials == "1");
        }

        public static void GetClientInfo(VehicleInGarageInformation i_ChosenVehicle)
        {
            string ownerName, ownerPhoneNumber, carConditionSelected;
            int parseCarConditionSelected;
            eVehicleCondition eVehicleCondition;

            Console.WriteLine("Enter your name");
            ownerName = Console.ReadLine();
            Console.WriteLine("Enter your phone number");
            ownerPhoneNumber = Console.ReadLine();
            Console.WriteLine("enter car's condition");

            while (true)
            {
                try
                {
                    foreach (eVehicleCondition condition in Enum.GetValues(typeof(eVehicleCondition)))
                    {
                        Console.WriteLine($"{(int)condition} : {condition}");
                    }

                    carConditionSelected = Console.ReadLine();

                    if (!int.TryParse(carConditionSelected, out parseCarConditionSelected))
                    {
                        throw new FormatException("Please enter a valid number.");
                    }
                    else
                    {
                        if (parseCarConditionSelected < 0 || parseCarConditionSelected > 2)
                        {
                            throw new ValueOutOfRangeException("Color selection should be between 0-2!.", 0, 2);
                        }

                        eVehicleCondition = (eVehicleCondition)Enum.GetValues(typeof(eVehicleCondition)).GetValue(parseCarConditionSelected);
                        break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            (i_ChosenVehicle).OwnerName = ownerName;
            (i_ChosenVehicle).OwnerPhoneNumber = ownerPhoneNumber;
            (i_ChosenVehicle).VehicleCondition = eVehicleCondition;
        }
        
        public static void DisplayLicenceNumbers()
        {
            string isFilter ,conditionTypeSelected;
            int parseconditionTypeSelected;
            string[] filteredLicence = new string[] { };
            eVehicleCondition condition = eVehicleCondition.UnderRepair;

            Console.WriteLine("Press 1 if you wish to filter by their condition , press any other ket otherwise.");
            isFilter = Console.ReadLine();
            if (isFilter != "1")
            {
                filteredLicence = m_Garage.GetLicenceArray(isFilter , condition);
            }
            else
            { 
                while (true)
                {

                    try
                    {
                        foreach (eVehicleCondition conditionIterator in Enum.GetValues(typeof(eVehicleCondition)))
                        {
                            Console.WriteLine($"{(int)conditionIterator}: {conditionIterator}");
                        }

                        conditionTypeSelected = Console.ReadLine();

                        if (!int.TryParse(conditionTypeSelected, out parseconditionTypeSelected))
                        {
                            throw new FormatException("Enter a valid number");
                        }
                        else if (parseconditionTypeSelected < 0 || parseconditionTypeSelected > 2)
                        {
                            throw new ValueOutOfRangeException("condition type selection should be between 0-2!.", 0, 2);
                        }

                        condition = (eVehicleCondition)Enum.GetValues(typeof(eVehicleCondition)).GetValue(parseconditionTypeSelected);
                        filteredLicence = m_Garage.GetLicenceArray(isFilter, condition);
                        break;
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            foreach (string licence in filteredLicence)
            {
                Console.WriteLine(licence);
            }
        }
    }
}
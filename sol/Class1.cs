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
        public abstract class Vehicle
        {
            public string Manufacturer { get; set; }
            public eCarColors e1;

            public eCarColors E1
            {
                get { return e1; }
                set { e1 = value; }
            }
            public virtual void StartEngine()
            {
                Console.WriteLine($"{Manufacturer} vehicle engine starts");
            }

            public virtual Dictionary<string, Type> GetParameters()
            {
                var parameters = new Dictionary<string, Type>();
                parameters.Add(nameof(Manufacturer), typeof(string));
                return parameters;
            }
        }

        // Derived class 1
        public class Car : Vehicle
        {
            public int NumberOfDoors { get; set; }
           
            public override void StartEngine()
            {
                Console.WriteLine($"Car engine starts with {NumberOfDoors} doors");
            }

            public override Dictionary<string, Type> GetParameters()
            {
                var parameters = base.GetParameters();
                parameters.Add(nameof(NumberOfDoors), typeof(int));
                parameters.Add(nameof(e1),typeof(eCarColors));
                return parameters;
            }

        }

        // Derived class 2
        class FuelCar : Car
        {
            FuelSystem fuelSystem;
            public bool IsTurbocharged { get; set; }

            // Additional property for FuelCar
            public string FuelType { get; set; }

            // Override the StartEngine method
            public override void StartEngine()
            {
                Console.WriteLine($"FuelCar engine starts with {FuelType} fuel{(IsTurbocharged ? " and is turbocharged" : "")}");
            }

            public override Dictionary<string, Type> GetParameters()
            {
                var parameters = base.GetParameters();
                parameters.Add(nameof(IsTurbocharged), typeof(bool));
                parameters.Add(nameof(FuelType), typeof(string));
                parameters.Add(nameof(fuelSystem), typeof(FuelSystem)); 
                return parameters;
            }

        }

        public static void HandleEnumSelection(Type enumType)
        {
            // Display options to the user
            Console.WriteLine($"Select an option for {enumType.Name}:");
            foreach (var value in Enum.GetValues(enumType))
            {
                Console.WriteLine($"{(int)value}. {value}");
            }

            // Get user input
            int selectedOption;
            if (int.TryParse(Console.ReadLine(), out selectedOption) && Enum.IsDefined(enumType, selectedOption))
            {
                Enum selectedEnum = (Enum)Enum.ToObject(enumType, selectedOption);
                Console.WriteLine($"You selected: {selectedEnum}");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public static object HandleEnumSelection1(Type enumType)
        {
            int selectedOption, countEnumOptions = 0;


            Console.WriteLine($"Select an option for {enumType.Name}:");
            foreach (var value in Enum.GetValues(enumType))
            {
                countEnumOptions++;
                Console.WriteLine($"{(int)value}. {value}");
            }

            Console.Write("Enter your selection: ");

            while (true)
            {
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out selectedOption))
                    {
                        throw new FormatException("Enter a valid number");
                    }
                    else if (!Enum.IsDefined(enumType, selectedOption))
                    {
                        throw new ValueOutOfRangeException("Value out of range", 0, countEnumOptions);
                    }

                    return Enum.ToObject(enumType, selectedOption);

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

        class Program
        {
            public static void Main()
            {
                Vehicle v1 = new FuelCar();
                Dictionary<string, Type> dic = v1.GetParameters();
                Dictionary<string,object> dic1 =new Dictionary<string,object>();

                
                // Display collected parameters
                Console.WriteLine("Parameters:");
                foreach (KeyValuePair<string, Type> keyValuePair in dic)
                {
                    if (keyValuePair.Value.IsEnum)
                    {
                        dic1[keyValuePair.Key] = HandleEnumSelection1(keyValuePair.Value);
                        v1.E1 = (eCarColors)dic1[keyValuePair.Key];
                        Console.WriteLine("{0} {1}", keyValuePair.Key, keyValuePair.Value);
                    }
                
                    }
                }
        }

    }
}
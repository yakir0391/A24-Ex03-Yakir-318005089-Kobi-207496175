using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_EnergyLeft;
        protected List<Wheel> m_Wheels;

        public Vehicle(float maxAirPressure, int amount_of_wheels) 
        {
            this.m_Wheels = new List<Wheel>(amount_of_wheels);

            for (int i = 0; i < amount_of_wheels; i++)
            {
                this.m_Wheels.Add(new Wheel());
                this.m_Wheels[i].MaxAirPressure = maxAirPressure;
            }
        }   
        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
            set 
            {
                if (value > 100 || value < 0)
                {
                    throw new ValueOutOfRangeException("Value out of range", 0, 100);
                }
                else
                { 
                    m_EnergyLeft = value;
                } 
            }
        }

        public List<Wheel> Wheels
        {
            
            get { return m_Wheels; }
  
        }

        public virtual void GetParameters(Dictionary<string, Type> io_VehicleParameters)
        {
            io_VehicleParameters.Add("Model name" , typeof(string));
            io_VehicleParameters.Add("Current air pressure", typeof(float));
            io_VehicleParameters.Add("Manufacture name", typeof(string));
        }

        public virtual void SetParameters(Dictionary<string, object> io_SetParametersDict)
        {
            float currentAirPressure = 0;
            string manufactureName = "No name";

            foreach (string param in io_SetParametersDict.Keys)
            {
                if (param == "Model name")
                {
                    m_ModelName = (string)io_SetParametersDict[param];
                }
                else if (param == "Licence number")
                {
                    m_LicenseNumber = (string)io_SetParametersDict[param];
                }
                else if (param == "Current air pressure")
                {
                    currentAirPressure=(float)(io_SetParametersDict[param]);
                }
                else if (param == "Manufacture name")
                {
                    manufactureName = (string)io_SetParametersDict[param];
                }
            }

            SetWheelsInfo(currentAirPressure,Wheels.Count, manufactureName);
        }

        public void SetWheelsInfo(float i_CurrentAirPressure,int i_Amount_of_wheels, string i_ManufactureName)
        {
            this.m_Wheels[0].CurrentAirPressure = i_CurrentAirPressure;
            this.m_Wheels[0].ManufacturerName = i_ManufactureName;

            for (int i = 1; i < i_Amount_of_wheels; i++)
            {
                this.Wheels[i].CurrentAirPressure = this.Wheels[i - 1].CurrentAirPressure;
                this.Wheels[i].ManufacturerName = this.Wheels[i - 1].ManufacturerName;
            }
        }

        public void InflateAir()
        {
            foreach (Wheel wheel in this.Wheels)
            {
                wheel.InflatingAir(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public virtual void GetParmetersToDisplay(Dictionary<string, string> io_DisplayParameters)
        {
            int i = 0;

            io_DisplayParameters.Add("Model name: ", ModelName);
            io_DisplayParameters.Add("Licence number: ", LicenseNumber);
            io_DisplayParameters.Add("Energy left: ", EnergyLeft.ToString());
            foreach(Wheel wheel in Wheels)
            {
                io_DisplayParameters.Add($"Wheel {i} Manufacture name: ",wheel.ManufacturerName);
                io_DisplayParameters.Add($"Wheel {i++} Current air pressure: ", wheel.CurrentAirPressure.ToString());
            }
        }

        public abstract Type CheckVehicleSystem();

        public abstract void FillEnergySource(Dictionary<string, object> i_ParametersToFillUp);
    }
}
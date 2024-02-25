using System;
using System.Collections.Generic;
using System.Linq;
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
                this.m_Wheels.Add(new Wheel()); // Initialize each wheel object within the loop
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
            set { m_EnergyLeft = value; }
        }

        public List<Wheel> Wheels
        {
            
            get { return m_Wheels; }
  
        }

        public void SetMaxAirPressureAndAmountOfWheels(float i_MaxAirPressure,int i_Amount_of_wheels)
        {
            this.m_Wheels = new List<Wheel>(i_Amount_of_wheels);
            

            for (int i = 0; i < i_Amount_of_wheels; i++)
            {
                this.m_Wheels.Add(new Wheel()); // Initialize each wheel object within the loop
                this.m_Wheels[i].MaxAirPressure = i_MaxAirPressure;
            }
        }

        public void UpdateVehicleDetails(string i_ModelName, string i_LicenceNumber, float i_EnergyLeft, List<Wheel> i_Wheels)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenceNumber;
            this.m_EnergyLeft = i_EnergyLeft;
            this.m_Wheels = i_Wheels;
        }
    }
}
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

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
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
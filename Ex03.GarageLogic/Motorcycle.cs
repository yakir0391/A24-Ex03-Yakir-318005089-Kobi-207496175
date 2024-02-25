using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        protected eLicenceType m_LicenceType;
        protected int m_EngineCapcity;
        public Motorcycle(float maxAirPressure, int amount_of_wheels) : base(maxAirPressure, amount_of_wheels) 
        {
            
        }
        public eLicenceType LicenceType
        {
            get { return m_LicenceType; }
            set { m_LicenceType = value;}
        }

        public int EngineCapcity
        {
            get { return m_EngineCapcity;}
            set { m_EngineCapcity = value;}
        }

        public void UpdateMotorcycleDetails(eLicenceType i_LicenceType, int i_EngineCapcity)
        {
            this.m_LicenceType = i_LicenceType;
            this.m_EnergyLeft = i_EngineCapcity;
        }
    }
}

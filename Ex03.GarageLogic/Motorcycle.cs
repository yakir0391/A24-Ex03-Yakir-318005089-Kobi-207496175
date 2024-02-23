using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenceType m_LicenceType;
        private int m_EngineCapcity;

        public eLicenceType LicenceType
        {
            get { return m_LicenceType; }
        }

        public int EngineCapcity
        {
            get { return m_EngineCapcity;}
        }

        public void UpdateMotorcycleDetails(eLicenceType i_LicenceType, int i_EngineCapcity)
        {
            this.m_LicenceType = i_LicenceType;
            this.m_EnergyLeft = i_EngineCapcity;
        }
    }
}

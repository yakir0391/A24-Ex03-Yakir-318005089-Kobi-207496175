using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle: Motorcycle
    {
        ElectricSystem m_ElectricSystem;

        public ElectricMotorcycle(float maxAirPressure, int amount_of_wheels) : base(maxAirPressure, amount_of_wheels)
        {
            m_ElectricSystem = new ElectricSystem(4.8f);
        }

        public ElectricSystem ElectricSystem 
        {
            get { return m_ElectricSystem; }
        }

        public void UpdateElectricMotorcycleAndOwnerInfo(float i_RemainingBatteryTime, float i_BatteryLife)
        {
            this.m_ElectricSystem.UpdateElectricSystem(i_RemainingBatteryTime, i_BatteryLife);
        }
    }
}

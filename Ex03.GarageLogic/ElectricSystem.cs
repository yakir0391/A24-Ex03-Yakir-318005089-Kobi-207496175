using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricSystem
    {
        protected float m_RemainingBatteryTime;
        protected float m_BatteryLife;

        public float RemainingBatteryTime
        {
            get { return m_RemainingBatteryTime;}
        }
        
        public float BatteryLife
        {
            get { return m_BatteryLife; }
        }
        public void BatteryCharging(float numOfHours)
        {

        }
    }
}

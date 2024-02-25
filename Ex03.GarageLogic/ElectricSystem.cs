using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricSystem
    {
        private float m_RemainingBatteryTime;
        private float m_BatteryLife;

        public ElectricSystem(float BatteryLife) 
        {
            this.BatteryLife = BatteryLife;
        } 
   
        public float RemainingBatteryTime
        {
            get { return this.m_RemainingBatteryTime;}
            set 
            {
                if (value < this.BatteryLife)
                { 
                    this.m_RemainingBatteryTime = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("The current battery remaining is over the maximum !", 0, this.BatteryLife);
                }
            }
        }
        
        public float BatteryLife
        {
            get { return m_BatteryLife; }
            set { m_BatteryLife = value;}
        }

        public void UpdateElectricSystem(float i_RemainingBatteryTime, float i_BatteryLife)
        {
            this.m_RemainingBatteryTime = i_RemainingBatteryTime;
            this.m_BatteryLife = i_BatteryLife;
        }

        public void BatteryCharging(float numOfHours)
        {

        }
    }
}

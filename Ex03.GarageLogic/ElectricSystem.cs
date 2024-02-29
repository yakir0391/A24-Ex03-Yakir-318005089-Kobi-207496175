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
                if (value <= this.BatteryLife)
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

        public void Recharging(float i_HoursAmount)
        {
            if (i_HoursAmount + RemainingBatteryTime > BatteryLife)
            {
                throw new ValueOutOfRangeException("The amount you asked to fill is over the maximum", 0, BatteryLife);
            }
            else
            {
                RemainingBatteryTime += i_HoursAmount;
            }
        }

        public void GetParmetersToDisplay(Dictionary<string, string> i_DisplayParameters)
        {
            i_DisplayParameters.Add("Battery life: ", BatteryLife.ToString());
            i_DisplayParameters.Add("Remaining battery time: ", RemainingBatteryTime.ToString());
        }

        public void SetParameters(Dictionary<string, object> io_SetParametersDict, ref float io_EnergyLeft)
        {
            foreach (string param in io_SetParametersDict.Keys)
            {
                if (param == "Remaining battery time")
                {
                    RemainingBatteryTime = (float)io_SetParametersDict[param];
                    io_EnergyLeft = (RemainingBatteryTime / BatteryLife) * 100;
                }
            }
        }
        public void GetParameters(Dictionary<string, Type> i_VehicleParameters)
        {
            i_VehicleParameters.Add("Remaining battery time", typeof(float));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value <= m_MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("Current air pressure is over maximun", 0, MaxAirPressure);

                }
            }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }

        public void InflatingAir(float i_AirToAdd)
        {
            if (CurrentAirPressure + i_AirToAdd <= MaxAirPressure)
            { 
                this.CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException("Value out of range", 0, MaxAirPressure);
            }
        }
    }
}
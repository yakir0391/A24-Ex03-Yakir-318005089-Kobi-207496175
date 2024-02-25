using System;
using System.Collections.Generic;
using System.Linq;
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
                if (value + this.m_CurrentAirPressure < m_MaxAirPressure)
                {
                    m_CurrentAirPressure += value;
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

        public bool InflatingAir(float i_AirToAdd)
        {
            return true;
        }
    }
}
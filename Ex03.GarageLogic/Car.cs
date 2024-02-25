using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        protected eCarColors m_color;
        protected eNumberOfDoors m_NumberOfDoors;
        public Car(float maxAirPressure, int amount_of_wheels) : base(maxAirPressure, amount_of_wheels)
        {
            
        }
        public eCarColors Color
        {
            get { return m_color; }
            set { m_color = value; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public void UpdateCarDetails(eCarColors i_Color, eNumberOfDoors i_NumberOfDoors)
        {
            this.m_color = i_Color;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }

    }
}

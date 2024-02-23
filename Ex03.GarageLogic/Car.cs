using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColors m_color;
        private eNumberOfDoors m_NumberOfDoors;

        public eCarColors Color
        {
            get { return m_color; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
        }

        public void UpdateCarDetails(eCarColors i_Color, eNumberOfDoors i_NumberOfDoors)
        {
            this.m_color = i_Color;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }

    }
}

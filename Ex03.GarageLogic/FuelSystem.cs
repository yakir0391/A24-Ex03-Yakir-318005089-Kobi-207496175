using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelSystem
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelQuantity;
        private float m_MaxFuelQuantity;

        public eFuelType FuelType
        {
            get { return m_FuelType;}
        }

        public float CurrentFuelQuantity
        {
            get { return m_CurrentFuelQuantity; }

            set 
            {
                if (value + this.CurrentFuelQuantity < this.m_MaxFuelQuantity)
                {
                    m_CurrentFuelQuantity = value; 
                } 
            }
        }

        public float MaxFuelQuantity
        {
            get { return m_MaxFuelQuantity; }
        }

        public void Refueling(float litersAmount, eFuelType fuelType)
        {

        }
    }
}

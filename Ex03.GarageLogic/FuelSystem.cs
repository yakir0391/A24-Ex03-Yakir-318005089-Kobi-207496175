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

        public FuelSystem(eFuelType fuelType, float maxFuelQuantity)
        { 
            this.FuelType = fuelType;
            this.MaxFuelQuantity = maxFuelQuantity;
        }
      
        public eFuelType FuelType
        {
            get { return m_FuelType;}
            set { m_FuelType = value; }
        }

        public float CurrentFuelQuantity
        {
            get { return m_CurrentFuelQuantity; }

            set 
            {
                    if (value < this.m_MaxFuelQuantity)
                    {
                        m_CurrentFuelQuantity = value;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException("The current fuel quantity is over the maximum", 0, this.MaxFuelQuantity);
                    }
                
            }
        }

        public float MaxFuelQuantity
        {
            get { return m_MaxFuelQuantity; }
            set { m_MaxFuelQuantity = value;}
        }

        public void UpdateFuelSystem(eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity)
        {
            this.m_FuelType = i_FuelType;
            this.m_CurrentFuelQuantity= i_CurrentFuelQuantity;
            this.m_MaxFuelQuantity = i_MaxFuelQuantity;
        }

        public void Refueling(float litersAmount, eFuelType fuelType)
        {

        }
    }
}

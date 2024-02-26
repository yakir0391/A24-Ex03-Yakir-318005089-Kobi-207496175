using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private FuelSystem m_FuelSystem;

        public FuelMotorcycle(float maxAirPressure, int amount_of_wheels) : base(maxAirPressure, amount_of_wheels) 
        {
            m_FuelSystem = new FuelSystem(eFuelType.OCTAN98,58);
        }
        public FuelSystem FuelSystem
        {
            get { return m_FuelSystem; }
            set { m_FuelSystem = value;}
        }

        public void UpdateFuelMotorcycleAndOwnerInfo(eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity)
        {
            this.m_FuelSystem.UpdateFuelSystem(i_FuelType, i_CurrentFuelQuantity, i_MaxFuelQuantity);
        }
    }
}

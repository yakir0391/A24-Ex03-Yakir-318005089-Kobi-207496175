using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelCar: Car
    {
        private FuelSystem m_FuelSystem;

        public FuelCar(float maxAirPressure, int amount_of_wheels) : base( maxAirPressure,  amount_of_wheels)
        {
            this.m_FuelSystem = new FuelSystem(eFuelType.OCTAN95,58); 
        }

        public FuelSystem FuelSystem { get { return m_FuelSystem; } }
        public void UpdateFuelCarAndOwnerInfo(eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity)
        {
            this.m_FuelSystem.UpdateFuelSystem(i_FuelType, i_CurrentFuelQuantity, i_MaxFuelQuantity);
        }


    }
}

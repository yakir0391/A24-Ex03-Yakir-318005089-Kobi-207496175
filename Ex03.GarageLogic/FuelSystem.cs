using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            set {  m_FuelType = value;   }
        }

        public float CurrentFuelQuantity
        {
            get { return m_CurrentFuelQuantity; }

            set 
            {
                if (value <= this.m_MaxFuelQuantity)
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

        public void Refueling(float i_LitersAmount, eFuelType i_FuelType)
        {
            if (m_FuelType != i_FuelType)
            {
                throw new ArgumentException("Fuel type is not suitable\n");
            }
            if (i_LitersAmount + CurrentFuelQuantity > MaxFuelQuantity) 
            {
                throw new ValueOutOfRangeException("The amount you asked to fill is over the maximum\n", 0, MaxFuelQuantity);
            }
            else 
            {
                CurrentFuelQuantity += i_LitersAmount;
            }
        }

        public void GetParmetersToDisplay(Dictionary<string, string> io_DisplayParameters)
        {
            io_DisplayParameters.Add("Current fuel quantity: ", CurrentFuelQuantity.ToString());
            io_DisplayParameters.Add("fuel type: ", FuelType.ToString());
            io_DisplayParameters.Add("Max fuel quantity: ", MaxFuelQuantity.ToString());
        }

        public void Setparameters(Dictionary<string, object> io_SetParametersDict ,ref float io_EnergyLeft)
        {
            foreach (string param in io_SetParametersDict.Keys)
            {
                if (param == "Current fuel quantity")
                {
                    CurrentFuelQuantity = (float)io_SetParametersDict[param];
                    io_EnergyLeft = (CurrentFuelQuantity / MaxFuelQuantity) * 100;
                }

            }
        }
    }
}

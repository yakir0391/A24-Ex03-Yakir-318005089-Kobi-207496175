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

        public FuelMotorcycle()  
        {
            m_FuelSystem = new FuelSystem(eFuelType.OCTAN98,58);
        }
        public FuelSystem FuelSystem
        {
            get { return m_FuelSystem; }
            set { m_FuelSystem = value;}
        }

        public override void GetParameters(Dictionary<string, Type> io_VehicleParameters)
        {
            base.GetParameters(io_VehicleParameters);
            FuelSystem.GetParameters(io_VehicleParameters);
        }
        public override void SetParameters(Dictionary<string, object> io_SetParametersDict)
        {
            float energyLeft = 0;

            base.SetParameters(io_SetParametersDict);
            FuelSystem.Setparameters(io_SetParametersDict, ref energyLeft);
            EnergyLeft = energyLeft;
        }

        public override Type CheckVehicleSystem()
        {
            return typeof(FuelSystem);
        }

        public override void FillEnergySource(Dictionary<string, object> io_ParametersToFillUp)
        {
            FuelSystem.Refueling((float)io_ParametersToFillUp["Amount of fuel"], (eFuelType)io_ParametersToFillUp["Fuel type"]);
        }

        public override void GetParmetersToDisplay(Dictionary<string, string> io_DisplayParameters)
        {
            base.GetParmetersToDisplay(io_DisplayParameters);
            FuelSystem.GetParmetersToDisplay(io_DisplayParameters);
        }
    }
}

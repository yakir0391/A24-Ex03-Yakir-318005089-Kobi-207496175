using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle: Motorcycle
    {
        ElectricSystem m_ElectricSystem;

        public ElectricMotorcycle() 
        {
            m_ElectricSystem = new ElectricSystem(4.8f);
        }

        public ElectricSystem ElectricSystem 
        {
            get { return m_ElectricSystem; }
        }

        public override void GetParameters(Dictionary<string, Type> i_VehicleParameters)
        {
            base.GetParameters(i_VehicleParameters);
            ElectricSystem.GetParameters(i_VehicleParameters);
        }
        public override void SetParameters(Dictionary<string, object> io_SetParametersDict)
        {
            float energyLeft = 0;

            base.SetParameters(io_SetParametersDict);
            ElectricSystem.SetParameters(io_SetParametersDict, ref energyLeft);
            EnergyLeft = energyLeft;
        }

        public override Type CheckVehicleSystem()
        {
            return typeof(ElectricSystem);
        }

        public override void FillEnergySource(Dictionary<string, object> io_ParametersToFillUp)
        {
            ElectricSystem.Recharging((float)io_ParametersToFillUp["Amount of charging"]);
        }

        public override void GetParmetersToDisplay(Dictionary<string, string> io_DisplayParameters)
        {
            base.GetParmetersToDisplay(io_DisplayParameters);
            ElectricSystem.GetParmetersToDisplay(io_DisplayParameters);

        }
    }
}

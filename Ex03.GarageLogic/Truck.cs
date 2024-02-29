using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        protected bool m_IsTransportHazardousMaterials;
        protected float m_CargoVolume;
        public Truck() : base(28, 12) { }

        public bool IsTransportHazardousMaterials
        {
            get { return m_IsTransportHazardousMaterials; }
            set { m_IsTransportHazardousMaterials = value; }
        }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public override void GetParameters(Dictionary<string, Type> io_VehicleParameters)
        {
            base.GetParameters(io_VehicleParameters);
            io_VehicleParameters.Add("If transport hazardous materials", typeof(bool));
            io_VehicleParameters.Add("Cargo volume", typeof(float));
        }

        public override void SetParameters(Dictionary<string, object> io_SetParametersDict)
        {
            base.SetParameters(io_SetParametersDict);

            foreach (string param in io_SetParametersDict.Keys)
            {
                if (param == "If transport hazardous materials")
                {
                    IsTransportHazardousMaterials = (bool)io_SetParametersDict[param];
                }
                if (param == "Cargo volume")
                {
                    CargoVolume = (float)io_SetParametersDict[param];
                }
            }
        }
        public void UpdateTruckDetails(bool i_IsTransportHazardousMaterials, float i_CargoVolume)
        {
            this.m_IsTransportHazardousMaterials = i_IsTransportHazardousMaterials;
            this.m_CargoVolume = i_CargoVolume;
        }

        public override abstract Type CheckVehicleSystem();

        public override abstract void FillEnergySource(Dictionary<string, object> io_ParametersToFillUp);

        public override void GetParmetersToDisplay(Dictionary<string, string> io_DisplayParameters)
        {
            base.GetParmetersToDisplay(io_DisplayParameters);
            io_DisplayParameters.Add("Is Transport Hazardous Materials: ", (IsTransportHazardousMaterials == true) ? "yes" : "no");
            io_DisplayParameters.Add("Cargo Volume: ", CargoVolume.ToString());
        }
    }
}

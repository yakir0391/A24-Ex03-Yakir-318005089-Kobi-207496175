using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        protected bool m_IsTransportHazardousMaterials;
        protected float m_CargoVolume;
        public Truck(float maxAirPressure, int amount_of_wheels) : base(maxAirPressure, amount_of_wheels)
        {
            
        }

        public bool IsTransportHazardousMaterials
        {
            get { return m_IsTransportHazardousMaterials;}
            set { m_IsTransportHazardousMaterials = value; }    
        }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public void UpdateTruckDetails(bool i_IsTransportHazardousMaterials, float i_CargoVolume)
        {
            this.m_IsTransportHazardousMaterials = i_IsTransportHazardousMaterials;
            this.m_CargoVolume = i_CargoVolume;
        }
    }
}

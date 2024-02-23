using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsTransportHazardousMaterials;
        private float m_CargoVolume;

        public bool IsTransportHazardousMaterials
        {
            get { return m_IsTransportHazardousMaterials;}
        }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
        }

        public void UpdateTruckDetails(bool i_IsTransportHazardousMaterials, float i_CargoVolume)
        {
            this.m_IsTransportHazardousMaterials = i_IsTransportHazardousMaterials;
            this.m_CargoVolume = i_CargoVolume;
        }
    }
}

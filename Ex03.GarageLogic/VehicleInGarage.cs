using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleCondition m_VehicleCondition;

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }
        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }
        public eVehicleCondition VehicleCondition
        {
            get { return m_VehicleCondition; }
            set { m_VehicleCondition = value; }
        }
        public void UpdateVehicleInGarageDetails(string i_OwnerName, string i_OwnerPhoneNumber, eVehicleCondition i_VehicleCondition)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.m_VehicleCondition = i_VehicleCondition;
        }
    }
}

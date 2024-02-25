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
        VehicleInGarage m_VehicleInGarage;

        public ElectricMotorcycle(float maxAirPressure, int amount_of_wheels) : base(maxAirPressure, amount_of_wheels)
        {
            m_ElectricSystem = new ElectricSystem(4.8f);
            m_VehicleInGarage = new VehicleInGarage();
        }
        public VehicleInGarage VehicleInGarage
        {
            get { return m_VehicleInGarage; }

        }
        public ElectricSystem ElectricSystem { get { return m_ElectricSystem; } }
        public void UpdateElectricMotorcycleAndOwnerInfo(float i_RemainingBatteryTime, float i_BatteryLife, string i_OwnerName,
        string i_OwnerPhoneNumber, eVehicleCondition i_VehicleCondition)
        {
            this.m_ElectricSystem.UpdateElectricSystem(i_RemainingBatteryTime, i_BatteryLife);
            this.m_VehicleInGarage.UpdateVehicleInGarageDetails(i_OwnerName, i_OwnerPhoneNumber, i_VehicleCondition);
        }
    }
}

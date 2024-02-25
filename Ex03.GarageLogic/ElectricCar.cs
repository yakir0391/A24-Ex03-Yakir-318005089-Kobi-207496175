using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        ElectricSystem m_ElectricSystem;
        VehicleInGarage m_VehicleInGarage;

        public ElectricCar(float maxAirPressure, int amount_of_wheels) : base(maxAirPressure, amount_of_wheels)
        {
            this.m_ElectricSystem = new ElectricSystem(4.8f);
            this.m_VehicleInGarage = new VehicleInGarage();

        }
        public VehicleInGarage VehicleInGarage
        {
            get { return m_VehicleInGarage; }

        }
        public ElectricSystem ElectricSystem { get { return m_ElectricSystem;} }
        public void UpdateElectricCarAndOwnerInfo(float i_RemainingBatteryTime, float i_BatteryLife, string i_OwnerName,
            string i_OwnerPhoneNumber, eVehicleCondition i_VehicleCondition)
        {
            this.m_ElectricSystem.UpdateElectricSystem(i_RemainingBatteryTime, i_BatteryLife);
            this.m_VehicleInGarage.UpdateVehicleInGarageDetails(i_OwnerName,i_OwnerPhoneNumber, i_VehicleCondition);
        }
    }
}

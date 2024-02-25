using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTruck : Truck
    {
        FuelSystem m_FuelSystem;
        VehicleInGarage m_VehicleInGarage;
        public FuelTruck(float maxAirPressure, int amount_of_wheels) : base(maxAirPressure, amount_of_wheels)
        {
            m_FuelSystem = new FuelSystem(eFuelType.Soler,110);
            m_VehicleInGarage = new VehicleInGarage();
        }
        public FuelSystem FuelSystem { get { return m_FuelSystem; } }
        public VehicleInGarage VehicleInGarage
        {
            get { return m_VehicleInGarage; }

        }
        public void UpdateFuelTruckAndOwnerInfo(eFuelType i_FuelType, float i_CurrentFuelQuantity, float i_MaxFuelQuantity,
        string i_OwnerName, string i_OwnerPhoneNumber, eVehicleCondition i_VehicleCondition)
        {
            this.m_FuelSystem.UpdateFuelSystem(i_FuelType, i_CurrentFuelQuantity, i_MaxFuelQuantity);
            this.m_VehicleInGarage.UpdateVehicleInGarageDetails(i_OwnerName, i_OwnerPhoneNumber, i_VehicleCondition);
        }
    }
}

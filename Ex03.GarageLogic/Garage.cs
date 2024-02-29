using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, (Vehicle, VehicleInGarageInformation)> m_Vehicles = new Dictionary<string, (Vehicle, VehicleInGarageInformation)>();

        public Dictionary<string, (Vehicle, VehicleInGarageInformation)> Vehicles
        {
            get { return m_Vehicles; }
            set { m_Vehicles = value; }
        }

        public bool CheckIfLicenseNumberExist(string i_LicenseNumber)
        {
            bool isExist = false;

            foreach (string licenceNumber in m_Vehicles.Keys)
            {
                if (licenceNumber == i_LicenseNumber)
                {
                    isExist = true;
                }
            }

            return isExist;
        }

        public void UpdateStatusForVehicle(string i_LicenseNumber)
        {
            foreach (string licenceNumber in m_Vehicles.Keys)
            {
                if (licenceNumber == i_LicenseNumber)
                {
                    m_Vehicles[licenceNumber].Item2.VehicleCondition = eVehicleCondition.UnderRepair; 
                    break;
                }
            }
        }

        public List<string> GetLicenceArray(string i_Filtered,eVehicleCondition i_Condition)
        {
            List<string> licenceArr=new List<string>();

            foreach (KeyValuePair<string ,(Vehicle,VehicleInGarageInformation)> keyValuePair in m_Vehicles)
            {

                if(i_Filtered == "1")
                {
                    if(keyValuePair.Value.Item2.VehicleCondition == i_Condition)
                    {
                        licenceArr.Add(keyValuePair.Key);
                    }
                }
                else
                {
                    licenceArr.Add(keyValuePair.Key);
                }
            }

            return licenceArr;
        }
        public void ChangeVehicleStatus(string i_LicenceNumber, eVehicleCondition i_NewVehicleCondition)
        {
            foreach (KeyValuePair<string, (Vehicle, VehicleInGarageInformation)> keyValuePair in m_Vehicles)
            {
                if (keyValuePair.Key == i_LicenceNumber)
                {
                    keyValuePair.Value.Item2.VehicleCondition = i_NewVehicleCondition;
                    break;
                }
            }
        }
        public void GetClientParameters(Dictionary<string, string> io_ClientParameters, string i_LicenceNumber) 
        {
            io_ClientParameters.Add("Client name: ", Vehicles[i_LicenceNumber].Item2.OwnerName);
            io_ClientParameters.Add("Client phone number: ", Vehicles[i_LicenceNumber].Item2.OwnerPhoneNumber);
            io_ClientParameters.Add("Vehicle condition: ", Vehicles[i_LicenceNumber].Item2.VehicleCondition.ToString());
        }
    }
}

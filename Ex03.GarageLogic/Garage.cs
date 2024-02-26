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

        public string[] GetLicenceArray(string flag,eVehicleCondition i_Condition)
        {
            string[] licenceArr=new string[] { };

            foreach (KeyValuePair<string ,(Vehicle,VehicleInGarageInformation)> keyValuePair in m_Vehicles)
            {
                if(flag == "1")
                {
                    if(keyValuePair.Value.Item2.VehicleCondition == i_Condition)
                    {
                        licenceArr.Append(keyValuePair.Key);
                    }
                }
                else
                {
                    licenceArr.Append(keyValuePair.Key);
                }
            }

            return licenceArr;
        }


    }
}

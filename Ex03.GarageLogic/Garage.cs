using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public List<Vehicle> Vehicles 
        { 
            get {  return vehicles; } 
            set { vehicles = value; }
        }
        public bool CheckIfLicenseNumberExist(string i_LicenseNumber) 
        {
            return false;
        }
    }
}

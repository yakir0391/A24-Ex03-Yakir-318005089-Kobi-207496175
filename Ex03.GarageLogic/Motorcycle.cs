using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenceType m_LicenceType;
        protected int m_EngineCapcity;
        public Motorcycle() : base(29, 2) 
        {
            
        }
        public eLicenceType LicenceType
        {
            get { return m_LicenceType; }
            set { m_LicenceType = value;}
        }

        public int EngineCapcity
        {
            get { return m_EngineCapcity;}
            set 
            { 
                m_EngineCapcity = value;
            }
        }

        public override void GetParameters(Dictionary<string, Type> io_VehicleParameters)
        {
            base.GetParameters(io_VehicleParameters);
            io_VehicleParameters.Add("Licence type", typeof(eLicenceType));
            io_VehicleParameters.Add("Engine capacity", typeof(int));
        }

        public override void SetParameters(Dictionary<string, object> io_SetParametersDict)
        {
            base.SetParameters(io_SetParametersDict);

            foreach (string param in io_SetParametersDict.Keys)
            {
                if (param == "Licence type")
                {

                    LicenceType = (eLicenceType)io_SetParametersDict[param];
                }
                else if (param == "Engine capacity")
                {
                    
                    EngineCapcity = (int)io_SetParametersDict[param];
                }
            }
        }
        
        public override abstract Type CheckVehicleSystem();
        
        public override abstract void FillEnergySource(Dictionary<string, object> io_ParametersToFillUp);

        public override void GetParmetersToDisplay(Dictionary<string, string> io_DisplayParameters)
        {
            base.GetParmetersToDisplay (io_DisplayParameters);
            io_DisplayParameters.Add("Licence type: ",LicenceType.ToString());
            io_DisplayParameters.Add("Engine Capacity: ", EngineCapcity.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColors m_Color;
        protected eNumberOfDoors m_NumberOfDoors;

        public Car() : base(30, 5) { }
      
        public eCarColors Color
        {
            get { return m_Color; }
            set
            {
                m_Color = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public override void GetParameters(Dictionary<string, Type> io_VehicleParameters)
        {
            base.GetParameters(io_VehicleParameters);
            io_VehicleParameters.Add("Car colors", typeof(eCarColors));
            io_VehicleParameters.Add("Number of doors", typeof(eNumberOfDoors));
        }

        public override void SetParameters(Dictionary<string, object> io_SetParametersDict)
        {
            base.SetParameters(io_SetParametersDict);

            foreach (string param in io_SetParametersDict.Keys)
            {
                if (param == "Car colors")
                {
                    Color = (eCarColors)io_SetParametersDict[param];
                }
                if (param == "Number of doors")
                {
                    NumberOfDoors = (eNumberOfDoors)io_SetParametersDict[param];
                }
            }
        }

        public override abstract Type CheckVehicleSystem();

        public override abstract void FillEnergySource(Dictionary<string, object> io_ParametersToFillUp);

        public override void GetParmetersToDisplay(Dictionary<string, string> io_DisplayParameters)
        {
            base.GetParmetersToDisplay (io_DisplayParameters);
            io_DisplayParameters.Add("Car color: ", Color.ToString());
            io_DisplayParameters.Add("Car number of doors: ", (NumberOfDoors).ToString());
        }
    }
}

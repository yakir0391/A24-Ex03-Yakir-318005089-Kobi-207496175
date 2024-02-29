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

        public override void GetParameters(Dictionary<string, Type> i_VehicleParameters)
        {
            base.GetParameters(i_VehicleParameters);
            i_VehicleParameters.Add("Car colors", typeof(eCarColors));
            i_VehicleParameters.Add("Number of doors", typeof(eNumberOfDoors));
        }

        public override void SetParameters(Dictionary<string, object> setParametersDict)
        {
            base.SetParameters(setParametersDict);

            foreach (string param in setParametersDict.Keys)
            {
                if (param == "Car colors")
                {
                    Color = (eCarColors)setParametersDict[param];
                }
                if (param == "Number of doors")
                {
                    NumberOfDoors = (eNumberOfDoors)setParametersDict[param];
                }
            }
        }

        public override abstract Type CheckVehicleSystem();

        public override abstract void FillEnergySource(Dictionary<string, object> i_ParametersToFillUp);

        public override void GetParmetersToDisplay(Dictionary<string, string> i_DisplayParameters)
        {
            base.GetParmetersToDisplay (i_DisplayParameters);
            i_DisplayParameters.Add("Car color: ", Color.ToString());
            i_DisplayParameters.Add("Car number of doors: ", (NumberOfDoors).ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException(float minValue, float maxValue)
            : base($"Value is out of range. Allowed range: {minValue} to {maxValue}.")
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public ValueOutOfRangeException(string message, float minValue, float maxValue)
            : base(message)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public ValueOutOfRangeException(string message, Exception innerException, float minValue, float maxValue)
            : base(message, innerException)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }

}

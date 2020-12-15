using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        public SpeedMotorcycle(string model, int horsePower)
                : base(model, horsePower, 125)
        {
        }

        public override int HorsePower
        {
            get { return base.HorsePower; }
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                base.HorsePower = value;
            }
        }
    }
}

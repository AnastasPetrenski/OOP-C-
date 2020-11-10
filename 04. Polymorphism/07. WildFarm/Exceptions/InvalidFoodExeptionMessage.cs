using System;

namespace WildFarm.Exeptions
{
    public class InvalidFoodExeptionMessage : Exception
    {
        public InvalidFoodExeptionMessage(string message)
            : base(message)
        {

        }
    }
}

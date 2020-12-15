using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Common
{
    public class ExceptionMessages
    {
        public const string NullOrWhitespaceName = "Name cannot be null or white space!";

        public const string ServingLessOrEqualToZero = "Serving size cannot be less or equal to zero";

        public const string PriceLessOrEqualToZero = "Price cannot be less or equal to zero!";

        public const string NullOrWhitespaceBrand = "Brand cannot be null or white space!";

        public const string CapacityLessOrEqualToZero = "Capacity has to be greater than 0";

        public const string PeopleLessOrEqualToZero = "Cannot place zero or less people!";
    }
}

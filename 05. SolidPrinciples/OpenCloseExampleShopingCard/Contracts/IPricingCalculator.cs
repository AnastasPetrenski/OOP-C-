using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExampleShopingCard.Contracts
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}

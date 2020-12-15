﻿using OpenCloseExampleShopingCard.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExampleShopingCard.Rules
{
    public class EachPriceRule : IPriceRule
    {
        public decimal CalculatePrice(OrderItem item)
        {
            return item.Quantity * 5m;
        }

        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("EACH");
        }
    }
}

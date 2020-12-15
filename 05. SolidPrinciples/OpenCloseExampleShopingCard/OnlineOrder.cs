using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExampleShopingCard
{
    class OnlineOrder : Order
    {
        public OnlineOrder(Cart cart)
            : base(cart)
        {

        }

    }
}

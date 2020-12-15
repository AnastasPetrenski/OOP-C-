using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectOnlineShop.Models.Constracts
{
    public interface IProduct
    {
        string Name { get; }

        decimal Price { get; }

        int Quantity { get; }


    }
}

using P03._ShoppingCart;
using System;

namespace P03._ShoppingCart_Before
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new Cart();
            OrderItem firstOrder = new OrderItem();
            firstOrder.Sku = "EACH";
            firstOrder.Quantity = 2;
            OrderItem second = new OrderItem();
            second.Sku = "SPECIAL";
            second.Quantity = 3;
            cart.Add(firstOrder);
            cart.Add(second);
            var total = cart.TotalAmount();
            Console.WriteLine(total);
        }
    }
}

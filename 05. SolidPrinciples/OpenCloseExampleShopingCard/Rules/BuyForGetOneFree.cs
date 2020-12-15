using OpenCloseExampleShopingCard.Contracts;

namespace OpenCloseExampleShopingCard.Rules
{
    public class BuyForGetOneFree : IPriceRule
    {
        public decimal CalculatePrice(OrderItem item)
        {
            decimal total = 0m;

            total += item.Quantity * 1m;
            int setsOfFive = item.Quantity / 5;
            total -= setsOfFive * 1m;

            return total;
        }

        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("BFGO");
        }
    }
}

using OnlineShop.Models.Products.Contracts;

namespace OnlineShop.Models.Products.Peripherals.Contracts
{
    public interface IPeripheral : IProduct
    {
        string ConnectionType { get; }
    }
}

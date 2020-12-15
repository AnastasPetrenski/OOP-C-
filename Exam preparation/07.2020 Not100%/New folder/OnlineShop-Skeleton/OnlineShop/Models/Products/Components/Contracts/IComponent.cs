using OnlineShop.Models.Products.Contracts;

namespace OnlineShop.Models.Products.Components.Contracts
{
    public interface IComponent : IProduct
    {
        int Generation { get; }
    }
}

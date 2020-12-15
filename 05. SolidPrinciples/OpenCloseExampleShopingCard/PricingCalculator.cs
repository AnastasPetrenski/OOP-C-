using System.Collections.Generic;
using System.Linq;

using OpenCloseExampleShopingCard.Contracts;
using OpenCloseExampleShopingCard.Rules;

namespace OpenCloseExampleShopingCard
{
    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<IPriceRule> pricingRules;

        public PricingCalculator()
        {
            this.pricingRules = new List<IPriceRule>()
            {
                new EachPriceRule(),
                new PerGramPriceRule(),
                new SpecialPriceRule(),
                new BuyForGetOneFree()
            };
        }

        public decimal CalculatePrice(OrderItem item)
        {
            return this.pricingRules
                .First(r => r.IsMatch(item))
                .CalculatePrice(item);
        }
    }
}

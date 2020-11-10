using FactoryDesignPattern.Poduct;

namespace FactoryDesignPattern.Factory
{
    abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }
}

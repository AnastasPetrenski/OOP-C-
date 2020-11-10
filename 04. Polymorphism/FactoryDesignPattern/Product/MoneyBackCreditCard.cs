
namespace FactoryDesignPattern.Poduct
{
    class MoneyBackCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;

        public MoneyBackCreditCard(int creditLimit, int annualCharge)
        {
            _cardType = "MoneyBack";
            CreditLimit = creditLimit;
            AnnualCharge = annualCharge;
        }

        public override string CardType => _cardType;

        public override int CreditLimit 
        { 
            get => _creditLimit;
            set => _creditLimit = value;
        }
        public override int AnnualCharge 
        { 
            get => _annualCharge;
            set => _annualCharge = value;
        }    
    }
}

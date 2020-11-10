
namespace FactoryDesignPattern.Poduct
{
    class TitaniumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;

        public TitaniumCreditCard(int creditLimit, int annualCharge)
        {
            _cardType = "Titanium";
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

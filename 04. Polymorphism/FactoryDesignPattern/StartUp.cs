using FactoryDesignPattern.Factory;
using FactoryDesignPattern.Poduct;
using System;
using System.Threading;

namespace FactoryDesignPattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the card type you would like to visit: ");
            string card = Console.ReadLine();

            CardFactory factory = card.ToLower() switch
            {
                "moneyback" => new MoneyBackFactory(50000, 0),
                "titanium" => new TitaniumFactory(100000, 500),
                "platinum" => new PlatinumFactory(500000, 1000),
                _=> null
            };

            CreditCard creditCard = factory.GetCreditCard();
            Console.WriteLine("\nYour card details are below : \n");
            Console.WriteLine("Card Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}",
                creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);
            Console.ReadKey();
        }
    }
}

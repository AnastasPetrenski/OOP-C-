namespace Container
{
    public class BankAccount
    {
        public BankAccount(decimal ammount)
        {
            this.Ammount = ammount;
        }

        public decimal Ammount { get; private set; }

        public void Deposit(decimal ammount)
        {
            this.Ammount += ammount;
        }
    }
}

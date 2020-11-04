namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string CallingToOtherPhones(string number)
        {
            return $"Dialing... {number}";
        }
    }
}

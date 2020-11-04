using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string CallingToOtherPhones(string number)
        {
            return $"Calling... {number}";
        }

        public string WebSearching(string site)
        {
            return $"Browsing: {site}!";
        }
    }
}

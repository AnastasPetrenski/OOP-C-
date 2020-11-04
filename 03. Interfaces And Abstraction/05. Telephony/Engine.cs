using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class Engine
    {
        private ICollection<string> phones;
        private ICollection<string> sites;

        public Engine()
        {
            this.phones = new List<string>();
            this.sites = new List<string>();
        }

        public void Run()
        {
            this.phones = ParseInput();
            ValidateInput(this.phones, nameof(this.phones));

            this.sites = ParseInput();
            ValidateInput(this.sites, nameof(this.sites));
        }

        private List<string> ParseInput()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            return input;
        }

        private static void ValidateInput(IEnumerable<string> input, string type)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone phone = new StationaryPhone();

            if (type == "phones")
            {
                foreach (var item in input)
                {
                    if (item.Length == 10 && CheckNumberForLetter(item))
                    {
                        Console.WriteLine(smartphone.CallingToOtherPhones(item)); 
                    }
                    else if (item.Length == 7 && CheckNumberForLetter(item))
                    {
                        Console.WriteLine(phone.CallingToOtherPhones(item));
                    }
                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                }
            }
            else if (type == "sites")
            {
                foreach (var item in input)
                {
                    if (CheckSiteForDigits(item))
                    {
                        Console.WriteLine(smartphone.WebSearching(item));
                    }
                    else
                    {
                        Console.WriteLine("Invalid URL!");
                    }
                }
            }
            
        }

        private static bool CheckSiteForDigits(string item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (char.IsDigit(item[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckNumberForLetter(string item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (char.IsLetter(item[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

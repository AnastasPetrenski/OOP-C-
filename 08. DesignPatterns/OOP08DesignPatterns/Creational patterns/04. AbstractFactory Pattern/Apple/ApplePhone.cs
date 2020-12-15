using OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Apple
{
    public class ApplePhone : IMobilePhone
    {
        private Dictionary<string, int> phoneBook;
        private string name;
        private string phoneNumber;

        public ApplePhone()
        {
            phoneBook = new Dictionary<string, int>();
        }

        public string Name 
        { 
            get => name;
            private set => name = String.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Invalid name") : value;
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            private set => phoneNumber = String.IsNullOrWhiteSpace(value) && value.Length != 10 ? throw new ArgumentException("Invalid name") : value;
        }

        public void AddContact(string name, string number)
        {
            this.Name = name;
            this.PhoneNumber = number;
            if (!phoneBook.ContainsKey(name))
            {
                phoneBook.Add(name, int.Parse(number));
            }

            //replace number
            phoneBook[name] = int.Parse(number);
        }

        public void MakeCall(int phoneNumber)
        {
            if (phoneBook.Any(m => m.Value == phoneNumber))
            {
                var contact = this.phoneBook.FirstOrDefault(p => p.Value == phoneNumber);
                Console.WriteLine($"Outgoing call - {contact.Key}, {contact.Value}");
            }
        }
    }
}

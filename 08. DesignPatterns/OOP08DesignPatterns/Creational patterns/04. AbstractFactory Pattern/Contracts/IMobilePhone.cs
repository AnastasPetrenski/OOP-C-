using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._04._AbstractFactory_Pattern.Contracts
{
    public interface IMobilePhone
    {
        string Name { get; }
        string PhoneNumber { get; }

        void AddContact(string name, string phone);
        void MakeCall(int phoneNumber);
    }
}

using OOP03InterfacesAndAbstraction.Enums;
using OOP03InterfacesAndAbstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP03InterfacesAndAbstraction.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corpsEnum;

        public SpecialisedSoldier(int id, string name, string family, decimal salary, string corpsEnum) 
            : base(id, name, family, salary)
        {
            this.CorpsEnum = corpsEnum;
        }

        public string CorpsEnum 
        {
            get => this.corpsEnum;
            set
            {
                Corps corpsEnum;
                if (!Enum.TryParse<Corps>(value, out corpsEnum))
                {
                    throw new ArgumentException();
                }

                this.corpsEnum = corpsEnum.ToString();
            }
        }
    }
}

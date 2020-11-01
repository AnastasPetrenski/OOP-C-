using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private string name;
        private string family;

        public Human(string name, string family)
        {
            this.Name = name;
            this.Family = family;
        }

        public string Name 
        { 
            get { return this.name; } 
            set
            {
                if (!char.IsUpper(value.First()))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                this.name = value;
            }
        }

        public string Family 
        {
            get { return this.family; }
            set
            {
                if (!char.IsUpper(value.ToCharArray().First()))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: lastName");
                }

                this.family = value;
            }

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"First Name: {this.Name}")
                .AppendLine($"Last Name: {this.Family}");
            return sb.ToString();
        }
    }
}

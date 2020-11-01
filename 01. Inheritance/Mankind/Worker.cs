using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHours;

        public Worker(string name, string family, decimal weekSalary, decimal workHours) : base(name, family)
        {
            this.WeekSalary = weekSalary;
            this.WorkHours = workHours;
        }

        public decimal WeekSalary 
        {
            get { return this.weekSalary; }
            set 
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public decimal WorkHours 
        {
            get { return this.workHours; } 
            set
            {
                if (value <= 0 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.workHours = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = this.WeekSalary / (this.WorkHours * 5);
            return moneyPerHour;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .Append(base.ToString())
                .AppendLine($"Week Salary: {this.WeekSalary:f2}")
                .AppendLine($"Hours per day: {this.workHours:f2}")
                .Append($"Salary per hour: {this.MoneyPerHour():f2}");

            return  sb.ToString();
        }
    }
}

using System;

namespace Mankind
{
    public class Worker : Human
    {
        private double salary;
        private int workHours;
        private double hourSalary;

        public Worker(string firstName,string lastName,double salary, int workHours)
            :base(firstName, lastName)
        {
            this.Salary = salary;
            this.workHours = workHours;
            this.hourSalary = salary / workHours / 5;
        }

        public double Salary
        {
            get => this.salary;
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch!Argument: weekSalary");
                }

                this.salary = value;
            }
        }

        public int WorkHours
        {
            get => this.workHours;
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHours = value;
            }
        }
               
        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}" +
                $"Week Salary: {this.Salary:F2}{Environment.NewLine}" +
                $"Hours per day: {this.WorkHours:F2}{Environment.NewLine}" +
                $"Salary per hour: {this.hourSalary:F2}";
        }
    }
}

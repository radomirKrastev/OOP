namespace P03.DetailPrinter
{
    using System.Collections.Generic;
    
    public class Program
    {
        public static void Main()
        {
            var employees = new List<Employee>();
            
            var employee = new Employee("Stephan");
            var documents = new List<string>() { "Id", "License", "CV" };
            var manager = new Manager("Jikata", documents);

            employees.Add(employee);
            employees.Add(manager);

            var detailsPrinter = new DetailsPrinter(employees);

            detailsPrinter.PrintDetails();
        }
    }
}

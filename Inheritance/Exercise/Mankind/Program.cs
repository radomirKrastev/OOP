using System;

namespace Mankind
{
    public class Program
    {
        public static void Main()
        {
            var studentData = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var firstName = studentData[0];
            var lastName = studentData[1];
            var facultyNumber = studentData[2];

            var student = new Student(firstName, lastName, facultyNumber);

            var workerData = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var firstNameWorker = workerData[0];
            var lastNameWorker = workerData[1];
            var salary = double.Parse(workerData[2]);
            var workHours = int.Parse(workerData[3]);

            var worker = new Worker(firstNameWorker, lastNameWorker,salary,workHours);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
    }
}

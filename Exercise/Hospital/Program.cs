namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var doctors = new List<Doctor>();
            var departments = new List<Department>();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                var commandParts = command.Split();
                var departmentName = commandParts[0];
                var firstName = commandParts[1];
                var secondName = commandParts[2];
                var patient = commandParts[3];
                var doctorName = $"{firstName} {secondName}";

                AddDoctor(doctors, doctorName);
                AddDepartment(departments, departmentName);

                var currentDoctor = doctors.First(x => x.Name == doctorName);
                var currentDepartment = departments.First(x => x.Name == departmentName);
                currentDepartment.AddDoctor(currentDoctor);

                var departmentRooms = currentDepartment.Rooms;
                var freeRoom = departmentRooms.FirstOrDefault(x => x.FreeRooms > 0);

                if (freeRoom != null)
                {
                    currentDoctor.AddPatient(patient);
                    freeRoom.AddPatient(patient);
                }

                command = Console.ReadLine();
            }

            var outputRequirement = Console.ReadLine();

            while (outputRequirement != "End")
            {
                PrintOutput(doctors, departments, outputRequirement);
                outputRequirement = Console.ReadLine();
            }
        }

        private static void AddDoctor(List<Doctor> doctors, string name)
        {
            if (!doctors.Any(x => x.Name == name))
            {
                doctors.Add(new Doctor(name));
            }
        }

        private static void AddDepartment(List<Department> departments, string name)
        {
            if (!departments.Any(x => x.Name == name))
            {
                departments.Add(new Department(name));
            }
        }

        private static void PrintOutput(List<Doctor> doctors, List<Department> departments, string output)
        {
            var outputParts = output.Split();

            if (outputParts.Length == 1)
            {
                var currentDepartment = departments.First(x => x.Name == outputParts[0]);
                var occupiedRooms = currentDepartment.Rooms.Where(x => x.Patients.Count > 0).ToList();

                foreach (var room in occupiedRooms)
                {
                    Console.WriteLine(string.Join("\n", room.Patients));
                }
            }
            else if (outputParts.Length == 2 && int.TryParse(outputParts[1], out int room))
            {
                var currentDepartment = departments.First(x => x.Name == outputParts[0]);
                Console.WriteLine(string.Join("\n", currentDepartment.Rooms[room - 1].Patients.OrderBy(x => x)));
            }
            else
            {
                var doctorName = outputParts[0] + " " + outputParts[1];
                var currentDoctor = doctors.First(x => x.Name == doctorName);

                Console.WriteLine(string.Join("\n", currentDoctor.Patients.OrderBy(x => x)));
            }
        }
    }
}
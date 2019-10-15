namespace Hospital
{
    using System.Collections.Generic;

    public class Department
    {
        public Department(string name)
        {
            this.Rooms = new Room[20];

            for (int i = 0; i < this.Rooms.Length; i++)
            {
                this.Rooms[i] = new Room();
            }

            this.Name = name;
            this.Doctors = new List<Doctor>();
        }

        public string Name { get; private set; }
        public List<Doctor> Doctors { get; set; }
        public Room[] Rooms { get; private set; }

        public void AddDoctor(Doctor doctor)
        {
            this.Doctors.Add(doctor);
        }
    }
}

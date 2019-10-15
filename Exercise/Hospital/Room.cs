namespace Hospital
{
    using System.Collections.Generic;

    public class Room
    {
        private const int totalRooms = 3;
        
        public Room()
        {
            this.Patients = new List<string>();
        }

        public int FreeRooms { get; private set; } = totalRooms;
        public List<string> Patients;
        
        public void AddPatient(string patient)
        {
            this.Patients.Add(patient);
            this.FreeRooms -= 1;
        }
    }
}

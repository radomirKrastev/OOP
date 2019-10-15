namespace Hospital
{
    using System.Collections.Generic;

    public class Doctor
    {
        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<string>();
        }

        public string Name { get; private set; }
        public string Department { get; private set; }
        public List<string> Patients { get; private set; }
        
        public void AddPatient(string patient)
        {
            this.Patients.Add(patient);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Doctor))
            {
                return false;
            }

            var other = obj as Doctor;

            if (this.Name != other.Name || this.Department != other.Department || this.Patients != other.Patients)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Department.GetHashCode()+this.Patients.GetHashCode();
        }
    }
}

namespace StudentSystem.Students
{
    using System.Collections.Generic;

    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students { get; private set; }

        public void Add(string name, int age, double grade)
        {
            if (!this.Students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.Students[name] = student;
            }
        }

        public Student Get(string name)
        {
            var student = this.Students[name];

            return student;
        }
    }
}

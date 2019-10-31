namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Citizen(string name, int age, string id, string birthdate)
            : this(name, age)
        {
            this.id = id;
            this.birthdate = birthdate;
        }

        public string Name => this.name;
         
        public int Age => this.age;

        public string Birthdate => this.birthdate;

        public string Id => this.id;
    }
}

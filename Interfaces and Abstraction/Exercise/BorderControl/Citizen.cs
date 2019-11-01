namespace BorderControl
{
    public class Citizen : Passer
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.name = name;
            this.age = age;
            this.id = id;
        }

        public override string Id => this.id;
    }
}

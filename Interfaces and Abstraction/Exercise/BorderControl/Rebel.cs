namespace BorderControl
{
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name, int age, string group)
        {
            this.name = name;
            this.age = age;
            this.group = group;
        }

        public int Food => this.food;

        public string Name => this.name;

        public void BuyFood()
        {
            this.food += 5;
        }
    }
}

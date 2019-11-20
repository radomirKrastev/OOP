namespace ValidationAttributes
{
    using ValidationAttributes.CustomAttributes;

    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        public Person(string name, int age)
        {
            this.FullName = name;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MinAge,MaxAge)]
        public int Age { get; private set; }
    }
}

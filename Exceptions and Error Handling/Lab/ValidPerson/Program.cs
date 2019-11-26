namespace ValidPerson
{
    using System;
    public class Program
    {
        public static void Main()
        {
            //    Person validPerson = new Person("Gosho", "Ivanov", 54);
            //    Person emptyFirstNamePerson = new Person("", "Ivanov", 54);
            //    Person emptyLastNamePerson = new Person("Gosho", "", 54);
            //    Person nullFirstNamePerson = new Person(null, "Ivanov", 54);
            //    Person nullLastNamePerson = new Person("Gosho", null, 54);
            //    Person ageBelowMinimumPerson = new Person("Gosho", "Ivanov", -1);
            //    Person ageAboveMaximumPerson = new Person("Gosho", "Ivanov", 121);

            try
            {
                Person validPerson = new Person("asd", "asd", -1);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

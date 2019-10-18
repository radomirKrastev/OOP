namespace Animals
{
    using System;
    using Animals;

    public class StartUp
    {
        public static void Main()
        {
            var animal = Console.ReadLine();
            var soundProducer = new SoundProducer();           

            while (animal != "Beast!")
            {
                var animalData = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var name = animalData[0];
                int age;

                try
                {
                    if (!int.TryParse(animalData[1], out age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch(ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    animal = Console.ReadLine();
                    continue;
                }                

                var gender = string.Empty;

                if (animalData.Length == 3)
                {
                    gender = animalData[2];
                }

                try
                {
                    if (animal.ToLower() == "cat")
                    {
                        var cat = new Cat(name, age, gender, soundProducer);
                        Console.WriteLine(cat);
                        cat.ProduceSound();
                    }
                    else if (animal.ToLower() == "dog")
                    {
                        var dog = new Dog(name, age, gender, soundProducer);
                        Console.WriteLine(dog);
                        dog.ProduceSound();
                    }
                    else if (animal.ToLower() == "frog")
                    {
                        var frog = new Frog(name, age, gender, soundProducer);
                        Console.WriteLine(frog);
                        frog.ProduceSound();
                    }
                    else if (animal.ToLower() == "kitten")
                    {
                        var kitten = new Kitten(name, age, soundProducer);
                        Console.WriteLine(kitten);
                        kitten.ProduceSound();
                    }
                    else if (animal.ToLower() == "tomcat")
                    {
                        var tomcat = new Tomcat(name, age, soundProducer);
                        Console.WriteLine(tomcat);
                        tomcat.ProduceSound();
                    }
                }
                catch(ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                animal = Console.ReadLine();
            }
        }
    }
}

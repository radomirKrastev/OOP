namespace Animals
{
    using System;
    using System.Collections.Generic;
    using Animals;

    public class StartUp
    {
        public static void Main()
        {
            var soundProducer = new SoundProducer();
            var animals = new List<Animal>();

            var animalData = Console.ReadLine();

            while (animalData != "Beast!")
            {
                try
                {
                    var dataParts = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    var name = dataParts[0];
                    var age = int.Parse(dataParts[1]);

                    var gender = string.Empty;

                    if (dataParts.Length == 3)
                    {
                        gender = dataParts[2];
                    }

                    if (animalData.ToLower() == "cat")
                    {
                        animals.Add(new Cat(name, age, gender, soundProducer));
                    }
                    else if (animalData.ToLower() == "dog")
                    {
                        animals.Add(new Dog(name, age, gender, soundProducer));
                    }
                    else if (animalData.ToLower() == "frog")
                    {
                        animals.Add(new Frog(name, age, gender, soundProducer));
                    }
                    else if (animalData.ToLower() == "kitten")
                    {
                        gender = "Female";
                        animals.Add(new Kitten(name, age, gender, soundProducer));
                    }
                    else if (animalData.ToLower() == "tomcat")
                    {
                        gender = "Male";
                        animals.Add(new Tomcat(name, age, gender, soundProducer));
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                animalData = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
                animal.ProduceSound();
            }
        }

    }
}

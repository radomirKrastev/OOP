namespace WildFarm
{
    using Animals;
    using Animals.Birds;
    using Animals.Mammals;
    using Animals.Mammals.Felines;

    public static class AnimalFactory
    {
        public static Animal InitializeAnimal(string[] animalInformation)
        {
            var type = animalInformation[0];
            var name = animalInformation[1];
            var weight = double.Parse(animalInformation[2]);
            
            if (type == "Owl")
            {
                var wingSize = double.Parse(animalInformation[3]);

                return new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                var wingSize = double.Parse(animalInformation[3]);

                return new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                var livingRegion = animalInformation[3];

                return new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                var livingRegion = animalInformation[3];

                return new Dog(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                var livingRegion = animalInformation[3];
                var breed = animalInformation[4];

                return new Cat(name, weight, livingRegion, breed);
            }
            else
            {
                var livingRegion = animalInformation[3];
                var breed = animalInformation[4];

                return new Tiger(name, weight, livingRegion, breed);
            }
        }
    }
}

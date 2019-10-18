namespace Animals.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender, ISoundProducable soundProducer)
            : base(name, age, gender, soundProducer)
        {
            this.Sound = "Woof!";
        }

        public override void ProduceSound()
        {
            this.SoundProducer.ProduceSound(this.Sound);
        }
    }
}

namespace Animals.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, ISoundProducable soundProducer)
            : base(name, age, soundProducer)
        {
        }

        public Cat(string name, int age, string gender, ISoundProducable soundProducer)
            : base(name, age, gender, soundProducer)
        {
            this.Sound="Meow meow";
        }

        public override void ProduceSound()
        {
            this.SoundProducer.ProduceSound(this.Sound);
        }
    }
}

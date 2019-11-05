namespace Animals.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender, ISoundProducable soundProducer)
            : base(name, age, gender, soundProducer)
        {
            this.Sound = "Meow meow";
        }

        public override void ProduceSound()
        {
            this.SoundProducer.ProduceSound(this.Sound);
        }
    }
}

namespace Animals.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, ISoundProducable soundProducer)
            : base(name, age, soundProducer)
        {
            base.Gender = "Female";
            this.Sound = "Meow";
        }

        public override void ProduceSound()
        {
            this.SoundProducer.ProduceSound(this.Sound);
        }
    }
}

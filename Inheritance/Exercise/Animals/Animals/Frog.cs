namespace Animals.Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender, ISoundProducable soundProducer)
            : base(name, age, gender, soundProducer)
        {
            this.Sound = "Ribbit";
        }

        public override void ProduceSound()
        {
            this.SoundProducer.ProduceSound(this.Sound);
        }
    }
}

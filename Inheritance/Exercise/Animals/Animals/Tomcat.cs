namespace Animals.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, ISoundProducable soundProducer)
            : base(name, age, soundProducer)
        {
            base.Gender = "Male";
            this.Sound = "MEOW";
        }

        public override void ProduceSound()
        {
            this.SoundProducer.ProduceSound(this.Sound);
        }
    }
}

namespace Animals.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender, ISoundProducable soundProducer)
            : base(name, age, gender, soundProducer)
        {
            this.Sound = "MEOW";
        }

        public override void ProduceSound()
        {
            this.SoundProducer.ProduceSound(this.Sound);
        }
    }
}

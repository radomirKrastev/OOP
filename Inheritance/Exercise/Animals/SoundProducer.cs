using System;

namespace Animals
{
    public class SoundProducer : ISoundProducable
    {
        public void ProduceSound(object sound)
        {
            Console.WriteLine(sound);
        }
    }
}

﻿using System;

namespace Animals.Animals
{
    public class Animal
    {
        private int age;
        private string name;
        private string gender;

        public Animal(string name, int age, string gender, ISoundProducable soundProducer)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.gender = gender;
            this.SoundProducer = soundProducer;
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }           

        public int Age
        {
            get => this.age;
            protected set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            protected set
            {
                if (string.IsNullOrEmpty(value) || (value.ToLower() != "male" && value.ToLower() != "female"))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public string Sound { get; protected set; }
        public ISoundProducable SoundProducer { get; protected set; }

        public virtual void ProduceSound()
        {
            SoundProducer.ProduceSound(this.Sound);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}{Environment.NewLine}" +
                $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}

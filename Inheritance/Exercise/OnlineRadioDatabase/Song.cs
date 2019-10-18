using System;

namespace OnlineRadioDatabase
{
    public class Song
    {
        private string singer;
        private string name;
        private int length;
        private string lengthData;

        public Song(string singer, string name, string lengthData)
        {
            this.Singer = singer;
            this.Name = name;
            this.lengthData = lengthData;
            AddSongLength();
        }

        public int Length => this.length;

        public string Singer
        {
            get => this.singer;
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }

                this.singer = value;
            }
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }

                this.name = value;
            }
        }

        private void AddSongLength()
        {
            var seconds = int.Parse(this.lengthData.Split(":")[1]);
            var minutes = int.Parse(this.lengthData.Split(":")[0]);
            var minutesAsSeconds = minutes*60;
            var timeLimitAsSeconds = 14 * 60 + 59;

            if (seconds + minutesAsSeconds > timeLimitAsSeconds || seconds + minutesAsSeconds < 0)
            {
                throw new ArgumentException("Invalid song length.");
            }

            if (minutes < 0 || minutes > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }

            if (seconds < 0 || seconds> 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }

            this.length = seconds + minutesAsSeconds;
        }
    }
}

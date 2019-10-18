using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDatabase
{
    public class Playlist
    {
        private List<Song> songs = new List<Song>();

        public void Add(Song song)
        {
            this.songs.Add(song);
        }

        public List<Song> Songs => this.songs;

        public override string ToString()
        {
            var totalSeconds = this.songs.Select(x => x.Length).Sum();
            
            var hours = totalSeconds / 60 / 60;
            var minutes = (totalSeconds - hours*60*60)/60;
            var seconds = totalSeconds-(minutes*60+hours*60*60);

            return $"Playlist length: {hours}h {minutes}m {seconds}s";
        }   
    }
}

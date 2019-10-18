using System;

namespace OnlineRadioDatabase
{
    public class Program
    {
        public static void Main()
        {
            var playList = new Playlist();
            var songsToAdd = int.Parse(Console.ReadLine());

            for (int i = 0; i < songsToAdd; i++)
            {
                var songData = Console.ReadLine();
                var dataParts = songData.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (dataParts.Length < 3)
                    {
                        throw new ArgumentException("Invalid song.");
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message); 
                }

                var singer = dataParts[0];
                var name = dataParts[1];
                var length = dataParts[2];
                try
                {
                    var song = new Song(singer, name, length);

                    playList.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch(ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine($"Songs added: {playList.Songs.Count}");
            Console.WriteLine(playList);
        }
    }
}

using System;

namespace OnlineRadioDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PlayList playlist = new PlayList();

            for (int i = 0; i < n; i++)
            {
                var arguments = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Song song = new Song(arguments);
                    Console.WriteLine(playlist.AddSong(song));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(playlist);
        }
    }
}

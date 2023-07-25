namespace Music;

class Program
{
    static void Main(string[] args)
    {
        var song1 = new Track("Another Love", "Tom Odell");
        var song2 = new Track("Yeletskiy's aria", "Dmitri Hvorostovski");
        var song3 = new Track("Love yourself", "Justin Bieber");

        var musicPlayer = new MusicPlayer();
        musicPlayer.Player.Add(song1);
        musicPlayer.Player.Add(song2);
        musicPlayer.Player.Add(song3);

        musicPlayer.Play();

        while (true)
        {
            Console.Write("Choose a command (next - n, previous - p, pause - pause, play - play, exit - e): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "n" or "next":
                    musicPlayer.Next();
                    break;

                case "p" or "previous":
                    musicPlayer.Previous();
                    break;

                case "pause":
                    musicPlayer.Pause();
                    break;

                case "play":
                    musicPlayer.Play();
                    break;

                case "e" or "exit":
                    return;
            }
        }
    }
}

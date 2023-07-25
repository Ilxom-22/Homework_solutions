namespace Music;

public class MusicPlayer
{
    public readonly List<Track> Player = new List<Track>();
    public int Track = 0;
    public bool IsPaused = true;



    public void Next()
    {
        if (Track == Player.Count - 1)
            Track = 0;
        else
            Track++;

        IsPaused = true;
        Play();
    }



    public void Previous()
    {
        if (Track > 0)
            Track--;
        else
            Track = Player.Count - 1;

        IsPaused = true;
        Play();
    }



    public void Pause()
    {
        if (!IsPaused)
        {
            Console.WriteLine($"\"Paused - {Player[Track].Author} - {Player[Track].Name}\"");
            IsPaused = true;
        }
        else
        {
            Console.WriteLine("The music is already paused!");
        }
    }



    public void Play()
    {
        if (IsPaused)
        {
            Console.WriteLine($"\"Playing - {Player[Track].Author} - {Player[Track].Name}\"");
            IsPaused = false;
        }
        else
        {
            Console.WriteLine("The music is already playing");
        }
    }
}
namespace Music_Task;

public abstract class MusicService
{
    protected readonly List<Music> musicList;
    protected int musicId;

    public MusicService()
    {
        musicList = new List<Music>();
    }

    public virtual void SwitchNext()
    {
        var music = musicList[++musicId];
        DisplayCurrentSong(music);
    }

    public virtual void SwitchPrevious()
    {
        var music = musicList[--musicId];
        DisplayCurrentSong(music);
    }

    public virtual void DisplayCurrentSong(Music music)
    {
        var message = MessageConstants.CurrentMusicMessage;
                          
        Console.WriteLine(message.Replace(MessageConstants.MusicNameToken, music.Name)
                           .Replace(MessageConstants.UserNameToken, music.SingerName));
    }

    public abstract void Add(string name, string singerName);
}

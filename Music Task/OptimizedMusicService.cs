namespace Music_Task;

public sealed class OptimizedMusicService : MusicService
{
    public override void Add(string name, string singerName)
    {
        var music = new Music(name, singerName);

        if (!musicList.Any(m => m.Equals(music)))
            musicList.Add(music);
    }

    public override void SwitchNext()
    {
        EnsureMusicListIsNotEmpty();
        if (IsCurrentTheLastOne())
            SwitchToFirst();
        else
            musicId++;

        var music = musicList[musicId];
        DisplayCurrentSong(music);
    }

    public override void SwitchPrevious()
    {
        EnsureMusicListIsNotEmpty();

        if (IsCurrentTheFirstOne())
            SwitchToLast();
        else
            musicId--;

        var music = musicList[musicId];
        DisplayCurrentSong(music);
    }

    private void SwitchToFirst()
    {
        musicId = 0;
    }

    private void SwitchToLast()
    {
        musicId = musicList.Count - 1;
    }

    private bool IsCurrentTheLastOne()
    {
        return musicId == musicList.Count - 1;
    }

    private bool IsCurrentTheFirstOne()
    {
        return musicId == 0;
    }

    private void EnsureMusicListIsNotEmpty()
    {
        if( !musicList.Any())
            throw new InvalidOperationException("Music Playlist is empty!");
    }
}

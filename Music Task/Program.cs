using Music_Task;

List<Music> musicTracks = new List<Music>
{
    new Music("Summer Breeze", "John Smith"),
    new Music("Moonlit Serenade", "Emily Davis"),
    new Music("Electric Groove", "The Beatmakers"),
    new Music("Melancholy Melodies", "Sarah Johnson"),
    new Music("Rhythmic Fusion", "Alex Rivera")
};

var service = new OptimizedMusicService();
foreach (var i in musicTracks)
    service.Add(i.Name, i.SingerName);


while (true)
{
    Console.Write("1. Switch to next\n2. Switch to previous\n3. Exit\n>> ");
   
    switch (Console.ReadLine())
    {
        case "1":
            service.SwitchNext(); 
            break;
        case "2":
            service.SwitchPrevious();
            break;
        case "3":
            return;
    }
       
}
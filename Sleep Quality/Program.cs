namespace SleepQuality;

class Program
{
    static void Main(string[] args)
    {
        DateOnly[] dates = {
            new (2023, 7, 15),
            new (2023, 7, 16),
            new (2023, 7, 17),
            new (2023, 7, 18),
            new (2023, 7, 19),
        };

        TimeSpan[] durations = {
            new (8, 30, 0),
            new (7, 45, 0),
            new (6, 15, 0),
            new (9, 0, 0), 
            new (5, 45, 0)
        };

        int[] awakeningTimes = { 3, 2, 5, 1, 0 };
        double[] score = new double[5];

            

        for (var i = 0; i < dates.Length; i++)
        {
            TimeSpan missingHours = new();
            if (i == 0)
                missingHours = TimeSpan.FromHours(0);
            else 
                missingHours = TimeSpan.FromHours(8) > durations[i-1]
                    ? TimeSpan.FromHours(8) - durations[i-1]
                    : TimeSpan.FromMinutes(0);

            var awakeningIndex = awakeningTimes[i] / durations[i].TotalHours;
            score[i] = Math.Round((durations[i].TotalHours - awakeningIndex) / (8 + missingHours.TotalHours) * 10, 2);
        }

        SortByTime(dates, durations, awakeningTimes, score);

        for (var i = 0; i < dates.Length; i++)
            Console.WriteLine($"{dates[i]} - {durations[i].TotalHours} hours - {score[i]} score");
    }



    private static void SortByTime(DateOnly[] dates, TimeSpan[] durations, int[] awakeningTimes, double[] score)
    {
        for (var i = 0; i < dates.Length; i++)
            for (var j = i + 1; j < dates.Length; j++)
                if (dates[i] < dates[j])
                {
                    (dates[i], dates[j]) = (dates[j], dates[i]);
                    (durations[i], durations[j]) = (durations[j], durations[i]);
                    (awakeningTimes[i], awakeningTimes[j]) = (awakeningTimes[j], awakeningTimes[i]);
                    (score[i], score[j]) = (score[j], score[i]);
                }
    }
}
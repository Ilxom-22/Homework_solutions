namespace Exam_results
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] students =
            {
                "Isabella", "Alexander", "Sophia", "Nathaniel", "Olivia", "Gabriel",
                "Aurora", "Benjamin", "Arabella", "William"
            };
            int[] ratings = { 88, 40, 33, 97, 51, 74, 83, 90, 75, 92 };

            SortRatings(ratings, students);


            Console.WriteLine($"The biggest rating: {students[0]} - {ratings[0]} ball");
            Console.WriteLine($"The smallest rating: {students[ratings.Length - 1]}  -  {ratings[ratings.Length - 1]} ball");
            Console.WriteLine($"The average rating of all students: {AverageRating(ratings)} ball\n");
            Console.WriteLine($"Number of students who got 90 and above: {TopStudentsCount(ratings)}");
            Console.WriteLine($"Number of students who got 80 and above: {MiddleStudentsCount(ratings)}\n");

            Console.WriteLine("All students score: ");

            for (var i = 0; i < ratings.Length; i++)
            {
                if (ratings[i] >= 90)
                    Console.WriteLine($"{ratings[i]} - \"{students[i]} - Top\"");
                else if (ratings[i] >= 80 && ratings[i] < 90)
                    Console.WriteLine($"{ratings[i]} - \"{students[i]} - Good\"");
                else if (ratings[i] >= 70 && ratings[i] < 80)
                    Console.WriteLine($"{ratings[i]} - \"{students[i]} - Not Bad\"");
                else
                    Console.WriteLine($"{ratings[i]} - \"{students[i]} - Fail\"");
            }

        }

        private static int TopStudentsCount(int[] ratings)
        {
            int count = 0;

            for (var i = 0; i < ratings.Length; i++)
            {
                if (ratings[i] >= 90)
                    count++;
            }

            return count;
        }

        private static int MiddleStudentsCount(int[] ratings)
        {
            int count = 0;

            for (var i = 0; i < ratings.Length; i++)
            {
                if (ratings[i] >= 80 && ratings[i] < 90)
                    count++;
            }

            return count;
        }

        private static int AverageRating(int[] ratings)
        {
            int avg = 0;

            for (var i = 0; i < ratings.Length; i++)
                avg += ratings[i];

            return avg / ratings.Length;
        }
    

    private static void SortRatings(int[] ratings, string[] students)
        {
            for (var i = 0; i < ratings.Length; i++)
                for (var j = i + 1; j < ratings.Length; j++)
                    if (ratings[i] < ratings[j])
                    {
                        (ratings[i], ratings[j]) = (ratings[j], ratings[i]);
                        (students[i], students[j]) = (students[j], students[i]);
                    }
        }
    }
}

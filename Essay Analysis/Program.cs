namespace Essay_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var essayBall = 100;
            var essay = "Lorem ipsum dolor sit amet consectetur adipisicing elit. " +
                       "quaerat est quas commodi quibusdam labore, nihil doloribus quam temporibus inventore optio expedita consectetur " +
                       "voluptatem QUIDEM nulla soluta earum. Numquam rem alias minima culpa iste distinctio. Eum similique est consequuntur minus, " +
                       "odio nisi recusandae iure asperiores facere, reiciendis voluptate maiores! Repellat, dolorum!";

            var words = essay.Split();
            var sentences = essay.Split('.', '?', '!');
            var containsLargeWords = false;
            var repeatedWordsExistance = false;
            var twentyPercent = words.Length * 0.2f;
            Dictionary<string, int> counter = new Dictionary<string, int>();


            if (words.Length < 500)
                essayBall -= 5;

            
            
            foreach (var word in words)
            {
                var pivot = word.ToLower();
                if (word.Length > 20)
                    containsLargeWords = true;

                if (counter.ContainsKey(pivot))
                    counter[pivot]++;
                else
                    counter[pivot] = 1;

                if (counter[pivot] > twentyPercent)
                    repeatedWordsExistance = true;
            }

            if (containsLargeWords)
                essayBall -= 20;
            
            if (repeatedWordsExistance)
                essayBall -= 5;

        

            foreach (var sentence in sentences)
            {
                if (!string.IsNullOrWhiteSpace(sentence) && !(sentence.Trim()[0] >= 'A' && sentence.Trim()[0] <= 'Z'))
                    essayBall -= 5;

                var word = sentence.Trim().Split();
                for (int i = 1; i < word.Length; i++)
                {
                    if (word[i] != word[i].ToLower())
                        essayBall -= 10;
                }
            }

            Console.WriteLine(essayBall);
        }

    }
}
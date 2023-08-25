namespace Async_Document_Analyzer;

public class DocumentAnalyzer
{
    private int _rating = 100;



    public async Task<int> Rating(string path)
    {
        _rating = 100;
        var document = ReadText(path);
        var essay = document.Content;
        var words = essay.Split();
        var sentences = essay.Split('.', '?', '!');


        var task1 = WordCountPenalty(words);
        var task2 = LargeWordsPenalty(words);
        var task4 = RepeatedWordsPenalty(words);
        var task5 = FirstLetterNotCapitalPenalty(sentences);
        var task6 = MiddleWordCapitalPenalty(sentences);
       
        var result = Task.WhenAll();

        return _rating;
    }



    private async Task WordCountPenalty(string[] words)
    {
        if (words.Length < 500)
            _rating -= 5;
    }



    private async Task RepeatedWordsPenalty(string[] words)
    {
        var twentyPercent = words.Length * 0.2f;
        Dictionary<string, int> counter = new Dictionary<string, int>();


        foreach (var word in words)
        {
            var key = word.ToLower();

            if (counter.ContainsKey(key))
                counter[key]++;
            else
                counter[key] = 1;

            if (counter[key] > twentyPercent)
                _rating -= 5;
        }
    }



    private async Task LargeWordsPenalty(string[] words)
    {
        foreach (var word in words)
            if (word.Length > 20)
                _rating -= 20;
    }



    private async Task FirstLetterNotCapitalPenalty(string[] sentences)
    {
        foreach (var sentence in sentences)
            if (!string.IsNullOrWhiteSpace(sentence) && !(sentence.Trim()[0] >= 'A' && sentence.Trim()[0] <= 'Z'))
                _rating -= 5;
    }



    private async Task MiddleWordCapitalPenalty(string[] sentences)
    {
        foreach (var sentence in sentences)
        {
            var word = sentence.Trim().Split();
            for (int i = 1; i < word.Length; i++)
                if (word[i] != word[i].ToLower())
                    _rating -= 10;
        }
    }

    private Document ReadText(string path)
    {
        var text = File.ReadAllText(path);
        return new Document(text);
    }
}


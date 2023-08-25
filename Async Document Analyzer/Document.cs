namespace Async_Document_Analyzer;

public class Document
{
    public string Content { get; set; }

    public Document(string essay)
    {
        Content = essay;
    }
}

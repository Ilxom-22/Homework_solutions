using System.Text.RegularExpressions;

namespace Email;

public class Email
{
    private string _to;
    private string _from;
    private string _subject;
    private string _content;


    public Email(string to, string from, string subject, string content)
    {
        To = to;
        From = from;
        Subject = subject;
        Content = content;
    }


    public string To
    {
        get => _to;
        set => _to = CheckEmail(value) ? value : throw new ArgumentOutOfRangeException();
    }

    public string From
    {
        get => _from;
        set => _from = CheckEmail(value) ? value : throw new ArgumentOutOfRangeException();
    }

    public string Subject
    {
        get => _subject;
        set => _subject = CheckSubject(value) ? value : throw new ArgumentOutOfRangeException();
    }

    public string Content
    {
        get => _content;
        set => _content = CheckContent(value) ? value : throw new ArgumentOutOfRangeException();
    }



    public bool CheckEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$";
        return Regex.IsMatch(email, pattern);
    }



    private bool CheckSubject(string subject)
    {
        string pattern = @"^[\w\d\s!#$%&'*+\-/=?^_`{|}~]+( [\w\d\s!#$%&'*+\-/=?^_`{|}~]+)*$";
        return Regex.IsMatch(subject, pattern);
    }



    private bool CheckContent(string content)
    {
        string pattern = @"^[\w\d\s!#$%&'*+\-/=?^_`{|}~.,:;()\[\]<>]+( [\w\d\s!#$%&'*+\-/=?^_`{|}~.,:;()\[\]<>]+)*$";
        return Regex.IsMatch(content, pattern);
    }


    public override string ToString()
    {
        return @$"To: {_to}
From: {_from}
Subject: {_subject}
Content: {_content}";
    }
}
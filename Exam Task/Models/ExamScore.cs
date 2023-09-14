namespace Exam_Task.Models;

public class ExamScore
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public double Score { get; set; }

    public ExamScore(long id, long userId, double score)
    {
        Id = id;
        UserId = userId;
        Score = score;
    }

    public override string ToString()
        => $"{Id} {UserId} {Score}";
}
using Exam_Task.Models;
using Exam_Task.Services.Interfaces;

namespace Exam_Task.Services;

public class ExamScoreService : IExamScoresService
{
    private readonly List<ExamScore> _scoreList;

    public ExamScoreService()
    {
        _scoreList = new List<ExamScore>();
    }

    public void Add(ExamScore examScore)
    {
        if (Exists(examScore))
            throw new ArgumentException("Exam score for this user already exists!");

        _scoreList.Add(examScore);
    }

    public void Delete(long id)
    {
        var scoreIndex = _scoreList.FindIndex(score => score.Id == id);
        _scoreList.RemoveAt(scoreIndex);
    }

    public ExamScore Get(long id)
    {
        var examScore = _scoreList.FirstOrDefault(score => score.Id == id);
        if (examScore == null)
            throw new InvalidOperationException();

        return examScore;
    }

    public IEnumerable<ExamScore> GetAll()
        => _scoreList;

    public void Update(ExamScore examScore)
    {
        var oldScore = Get(examScore.Id);

        oldScore.UserId = examScore.UserId;
        oldScore.Score = examScore.Score;
    }

    private bool Exists(ExamScore newScore)
        => _scoreList.Any(score => score.UserId == newScore.UserId);
}
using Exam_Task.Services.Interfaces;

namespace Exam_Task.Services;

public class ExamAnalyticsService
{
    private IUserService _userService { get; set; }
    private IExamScoresService _examScoresService { get; set; }

    public ExamAnalyticsService(IUserService userService, IExamScoresService examScoresService)
    {
        _userService = userService;
        _examScoresService = examScoresService;
    }

    public IEnumerable<(string FullName, double Score)> GetScores()
    {
        var scores = _userService.GetAll()
            .Join(_examScoresService.GetAll(), 
                user => user.Id, 
                examScore => examScore.UserId,
                (User, Score) => new
                {
                    User = $"{User.FirstName} {User.LastName}",
                    Score = Score.Score
                })
        .Select(x => (x.User, x.Score));

        return scores;
    }
}
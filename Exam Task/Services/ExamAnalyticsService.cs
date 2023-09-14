using Exam_Task.Services.Interfaces;

namespace Exam_Task.Services;

public class ExamAnalyticsService
{
    public readonly IUserService UserService;
    public readonly IExamScoresService ExamScoresService;

    public ExamAnalyticsService(IUserService userService, IExamScoresService examScoresService)
    {
        UserService = userService;
        ExamScoresService = examScoresService;
    }

    public IEnumerable<(string FullName, double Score)> GetScores()
    {
        var scores = UserService.GetAll()
            .Join(ExamScoresService.GetAll(), 
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
using Exam_Task.Models;
using Exam_Task.Services;

var userService = new UserService();
var examScoresService = new ExamScoreService();
var examAnalyticsService = new ExamAnalyticsService(userService, examScoresService);

List<User> userList = new List<User>
{
    new User(1, "John", "Doe"),
    new User(2, "Alice", "Smith"),
    new User(3, "Bob", "Johnson"),
    new User(4, "Emily", "Brown"),
    new User(5, "Michael", "Wilson")
};

List<ExamScore> examScoreList = new List<ExamScore>
{
    new ExamScore(1, 1, 95.5),
    new ExamScore(2, 2, 87.0),
    new ExamScore(3, 3, 91.2),
    new ExamScore(4, 4, 78.9),
    new ExamScore(5, 5, 88.7) 
};

foreach (var user in userList)
    userService.Add(user);

foreach (var exam in examScoreList)
    examScoresService.Add(exam);


foreach (var i in examAnalyticsService.GetScores())
    Console.WriteLine(i);
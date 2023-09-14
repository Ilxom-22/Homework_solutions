using Exam_Task.Models;

namespace Exam_Task.Services.Interfaces;

public interface IExamScoresService
{
    void Add(ExamScore examScore);
    void Update(ExamScore examScore);
    void Delete(long id);
    ExamScore Get(long id);
    IEnumerable<ExamScore> GetAll();
}

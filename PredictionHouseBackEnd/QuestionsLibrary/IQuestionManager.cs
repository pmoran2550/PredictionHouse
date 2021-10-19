using System;
using System.Threading.Tasks;
using PTM.PHDomain;
using PTM.PredictionHouseDB;

namespace PTM.Questions
{
    public interface IQuestionManager
    {
        Task<QuestionListResponse> GetAllQuestionsAsync();
        Task<QuestionListResponse> GetQuestionsByYearAsync(int year);
        Task<PredictionHouseDB.Questions> GetQuestionByIDAsync(int id);
        Task<PredictionHouseDB.Questions> AddQuestion(PredictionHouseDB.Questions newQuestion);
    }
}

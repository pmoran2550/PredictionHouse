using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PTM.PHDomain;

namespace PTM.Questions
{
    public interface IQuestionAccessor
    {
        Task<IEnumerable<QuestionListItem>> GetQuestionsAsync();
        Task<IEnumerable<QuestionListItem>> GetQuestionsByYearAsync(int year);
        Task<PredictionHouseDB.Questions> GetQuestionByIDAsync(int id);
        Task<PredictionHouseDB.Questions> AddQuestion(PredictionHouseDB.Questions newQuestion);
        Task<bool> UpdateQuestionAnswer(string value, int id);
    }
}

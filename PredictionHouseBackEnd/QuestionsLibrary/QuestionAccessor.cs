using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PTM.PHDomain;
using PTM.PredictionHouseDB;

namespace PTM.Questions
{
    public class QuestionAccessor : IQuestionAccessor
    {
        private PredictionHouseContext _dbContext;

        public QuestionAccessor(PredictionHouseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<QuestionListItem>> GetQuestionsAsync()
        {
            IQueryable<PTM.PredictionHouseDB.Questions> dbQuestionsQuery = _dbContext.Questions;

            IQueryable<QuestionListItem> results = dbQuestionsQuery.Select(x =>
                new QuestionListItem
                {
                    QuestionID = x.QuestionId,
                    Question = x.Question,
                    Year = x.Year ?? default(int),
                    Answer = x.Answer
                });
            
            return await results.ToListAsync();
        }

        public async Task<IEnumerable<QuestionListItem>> GetQuestionsByYearAsync(int year)
        {
            IQueryable<PTM.PredictionHouseDB.Questions> dbQuestionsQuery = _dbContext
                .Questions
                .Where(x => x.Year == year);

            IQueryable<QuestionListItem> results = dbQuestionsQuery.Select(x =>
                new QuestionListItem
                {
                    QuestionID = x.QuestionId,
                    Question = x.Question,
                    Year = x.Year ?? default(int),
                    Answer = x.Answer
                });

            return await results.ToListAsync();
        }

        public async Task<PredictionHouseDB.Questions> GetQuestionByIDAsync(int id)
        {
            PredictionHouseDB.Questions dbQuestions = await _dbContext
                .Questions
                .SingleOrDefaultAsync(x => x.QuestionId == id);

            return dbQuestions;
        }

        public async Task<List<string>> GetYearsList()
        {
            List<int?> years = await _dbContext.Questions.Select(y => y.Year).Distinct().ToListAsync();
            List<string> yearsStr = new List<string>();
            foreach(int? year in years)
            {
                yearsStr.Add(year.ToString());
            }
            //List<string> yearsStr = ((IEnumerable<string>)years).ToList();

            return yearsStr;
        }

        public async Task<PredictionHouseDB.Questions> AddQuestion(PredictionHouseDB.Questions newQuestion)
        {
            PredictionHouseDB.Questions addedQ = null;

            try
            {
                addedQ = await _dbContext
                    .Questions
                    .SingleOrDefaultAsync(x => x.Question == newQuestion.Question && x.Year == newQuestion.Year);

                if (addedQ == null)
                {
                    var newQ = new PredictionHouseDB.Questions(newQuestion.Question, newQuestion.Year, newQuestion.Answer);
                    var addedResponse = await _dbContext.AddAsync(newQ);
                    await _dbContext.SaveChangesAsync();
                    addedQ = addedResponse.Entity;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error saving new question to DB: {0}", ex.Message);
                addedQ = null;
            }

            return addedQ;
        }

        public async Task<bool> UpdateQuestionAnswer(string value, int id)
        {
            bool response = false;
            try
            {
                var question = await _dbContext
                    .Questions
                    .SingleOrDefaultAsync(x => x.QuestionId == id);

                question.Answer = value;
                await _dbContext.SaveChangesAsync();
                response = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving new question to DB: {0}", ex.Message);
            }
            return response;
        }
    }
}

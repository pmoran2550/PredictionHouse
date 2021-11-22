using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTM.PHDomain;
using PTM.PredictionHouseDB;

namespace PTM.Questions
{
    public class QuestionManager : IQuestionManager
    {
        private PredictionHouseContext _dbContext;

        public QuestionManager(PredictionHouseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QuestionListResponse> GetAllQuestionsAsync()
        {
            QuestionListResponse response =  new QuestionListResponse();

            try
            {
                var questionAccessor = new QuestionAccessor(_dbContext);

                response.Data =  await questionAccessor.GetQuestionsAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<QuestionListResponse> GetQuestionsByYearAsync(int year)
        {
            QuestionListResponse response = new QuestionListResponse();

            try
            {
                var questionAccessor = new QuestionAccessor(_dbContext);

                response.Data = await questionAccessor.GetQuestionsByYearAsync(year);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<PredictionHouseDB.Questions> GetQuestionByIDAsync(int id)
        {
            var questionAccessor = new QuestionAccessor(_dbContext);
            PredictionHouseDB.Questions question = await questionAccessor.GetQuestionByIDAsync(id);

            return question;
        }

        public async Task<StringListResponse> GetYearsList()
        {
            StringListResponse response = new StringListResponse();
            List<string> years = new List<string>();

            try
            {
                var questionAccessor = new QuestionAccessor(_dbContext);

                years = await questionAccessor.GetYearsList();
                response.Success = true;
                response.Message = "";
                response.Data = years;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
            }

            return response;
        }

        public async Task<PredictionHouseDB.Questions> AddQuestion(PredictionHouseDB.Questions newQuestion)
        {
            var questionAccessor = new QuestionAccessor(_dbContext);

            PredictionHouseDB.Questions addedQ = await questionAccessor.AddQuestion(newQuestion);

            return addedQ;
        }

        public async Task<bool> UpdateQuestionAnswerAsync(string value, string idStr)
        {
            int id = Convert.ToInt32(idStr);
            var questionAccessor = new QuestionAccessor(_dbContext);
            var response = await questionAccessor.UpdateQuestionAnswer(value, id);

            return response;
        }
    }
}

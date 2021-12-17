using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PTM.PHDomain;
using PTM.PredictionHouseDB;

namespace PTM.Responses
{
    public class ResponsesAccessor
    {
        private PredictionHouseContext _dbContext;

        public ResponsesAccessor(PredictionHouseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ResponsesListItem>> GetResponsesAsync()
        {
            IQueryable<PTM.PredictionHouseDB.Responses> dbResponsesQuery = _dbContext.Responses;

            IQueryable<ResponsesListItem> results = dbResponsesQuery.Select(x =>
                new ResponsesListItem
                {
                   ResponseID = x.ResponseId,
                   QuestionID = x.QuestionId,
                   RespondentID = x.RespondentId,
                   Response = x.Response,
                   Correct = x.Correct
                });

            return await results.ToListAsync();
        }

        public async Task<IEnumerable<ResponsesListItem>> GetResponsesByRespondentAsync(int respondentId)
        {
            IQueryable<PredictionHouseDB.Responses> dbResponsesQuery = _dbContext
                .Responses
                .Where(x => x.RespondentId == respondentId);

            IQueryable<ResponsesListItem> results = dbResponsesQuery.Select(x =>
                new ResponsesListItem
                {
                    ResponseID = x.ResponseId,
                    RespondentID = x.RespondentId,
                    QuestionID = x.QuestionId,
                    Response = x.Response,
                    Correct = x.Correct
                });

            return await results.ToListAsync();
        }

        public async Task<IEnumerable<ResponsesListItem>> GetResponsesByYearList(int year)
        {
            var query = from r in _dbContext.Responses
                        from q in _dbContext.Questions
                        where q.Year == 2018
                        where r.QuestionId == q.QuestionId
                        select r;

            var results = query.Select(x =>
                new ResponsesListItem
                {
                    ResponseID = x.ResponseId,
                    RespondentID = x.RespondentId,
                    QuestionID = x.QuestionId,
                    Response = x.Response,
                    Correct = x.Correct
                });

            return await results.ToListAsync();
        }

        public async Task<PredictionHouseDB.Responses> AddResponseAsync(PredictionHouseDB.Responses newResponse)
        {
            PredictionHouseDB.Responses addedResponse = null;

            try
            {
                addedResponse = await _dbContext
                    .Responses
                    .SingleOrDefaultAsync(x => x.RespondentId == newResponse.RespondentId && 
                    x.QuestionId == newResponse.QuestionId);

                if (addedResponse == null)
                {
                    var newR = new PredictionHouseDB.Responses(newResponse.ResponseId, newResponse.QuestionId,
                        newResponse.RespondentId, newResponse.Response, newResponse.Correct);
                    var addedR = await _dbContext.AddAsync(newR);
                    await _dbContext.SaveChangesAsync();
                    addedResponse = addedR.Entity;
                }
                else
                {
                    addedResponse = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving new response to DB: {0}", ex.Message);
                addedResponse = null;
            }

            return addedResponse;
        }

        public async Task<bool> UpdateResponseAsync(string responseVal, int respondentId, int questionId)
        {
            bool result = false;
            try
            {
                var response = await _dbContext
                    .Responses
                    .SingleOrDefaultAsync(x => x.RespondentId == respondentId && 
                    x.QuestionId == questionId);

                if (response != null)
                {
                    response.Response = responseVal;
                    await _dbContext.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving new response to DB: {0}", ex.Message);
            }
            return result;
        }

    }
}

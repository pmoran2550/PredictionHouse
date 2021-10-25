using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PTM.PHDomain;
using PTM.PredictionHouseDB;

namespace PTM.Responses
{
    public class ResponsesManager
    {
        private PredictionHouseContext _dbContext;

        public ResponsesManager(PredictionHouseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponsesListResponse> GetAllResponsesAsync()
        {
            ResponsesListResponse response = new ResponsesListResponse();

            try
            {
                var responsesAccessor = new ResponsesAccessor(_dbContext);

                response.Data = await responsesAccessor.GetResponsesAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponsesListResponse> GetResponsesByRespondentAsync(int respondentId)
        {
            ResponsesListResponse response = new ResponsesListResponse();

            try
            {
                var responsesAccessor = new ResponsesAccessor(_dbContext);
                response.Data = await responsesAccessor.GetResponsesByRespondentAsync(respondentId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<PredictionHouseDB.Responses> AddResponseAsync(PredictionHouseDB.Responses newResponse)
        {
            var responsesAccessor = new ResponsesAccessor(_dbContext);

            PredictionHouseDB.Responses addedResponse = await responsesAccessor.AddResponseAsync(newResponse);

            return addedResponse;
        }
        public async Task<bool> UpdateResponseAsync(string value, int respondentId, int questionId)
        {
            var responsesAccessor = new ResponsesAccessor(_dbContext);
            var response = await responsesAccessor.UpdateResponseAsync(value, respondentId, questionId);

            return response;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PTM.PHDomain;
using PTM.PredictionHouseDB;

namespace PTM.RespondentLibrary
{
    public class RespondentManager
    {
        private PredictionHouseContext _dbContext;

        public RespondentManager(PredictionHouseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RespondentListResponse> GetAllRespondentsAsync()
        {
            RespondentListResponse response = new RespondentListResponse();

            try
            {
                var respondentAccessor = new RespondentAccessor(_dbContext);

                response.Data = await respondentAccessor.GetRespondentsAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

    }
}

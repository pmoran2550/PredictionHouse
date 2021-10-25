using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PTM.PHDomain;
using PTM.PredictionHouseDB;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PTM.RespondentLibrary
{
    public class RespondentAccessor
    {
        private PredictionHouseContext _dbContext;

        public RespondentAccessor(PredictionHouseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RespondentListItem>> GetRespondentsAsync()
        {
            IQueryable<Respondents> dbRespondentsQuery = _dbContext.Respondents;

            IQueryable<RespondentListItem> results = dbRespondentsQuery.Select(x =>
                new RespondentListItem
                {
                    RespondentName = x.RespondentName,
                    RespondentGroup = x.RespondentGroup,
                    RespondentID = x.RespondentId
                });

            return await results.ToListAsync();
        }
    }
}

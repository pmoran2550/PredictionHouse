using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTM.PHDomain;
using PTM.PredictionHouseDB;

namespace PTM.PredictionHouseBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespondentController : BaseController
    {
        public RespondentController(PredictionHouseContext dbContext) : base(dbContext)
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespondentListItem>>> GetAsync()
        {
            var allRespondents = await respondentManager.GetAllRespondentsAsync();

            if (allRespondents.Success)
                return Ok(allRespondents);
            else
                return BadRequest();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTM.PHDomain;
using PTM.PredictionHouseDB;
using PTM.PHDomain.API_Data_Model;

namespace PTM.PredictionHouseBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsesController : BaseController
    {
        public ResponsesController(PredictionHouseContext dbContext) : base(dbContext)
        {

        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ResponsesListItem>>> GetAsync()
        //{
        //    var allResponses = await responsesManager.GetAllResponsesAsync();
        //    return Ok(allResponses);
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsesListItem>>> GetResponsesByRespondentAsync(int respondentid)
        {
            if (respondentid > 0)
            {
                var respondentResponses = await responsesManager.GetResponsesByRespondentAsync(respondentid);
                if (respondentResponses.Success)
                    return Ok(respondentResponses);
                else
                    return NotFound();
            }
            else
            {
                var allResponses = await responsesManager.GetAllResponsesAsync();
                return Ok(allResponses);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PredictionHouseDB.Responses>> PostResponse(PredictionHouseDB.Responses newResponse)
        {
            PredictionHouseDB.Responses addedResponse = await responsesManager.AddResponseAsync(newResponse);

            if (addedResponse != null)
            {
                string uriStr = "api/responses/" + addedResponse.ResponseId.ToString();
                return Created(uriStr, addedResponse);
            }
            else
                return BadRequest();
        }

        [HttpPatch("{respondentid}")]
        public async Task<IActionResult> Patch([FromBody] PatchInstructions data, int respondentid, int questionid)
        {
            if (data == null)
                return NoContent();

            string operation = data.op;
            string path = data.path;
            string value = data.value;
            bool retVal = false;

            if (path != null)
            {
                if (operation.Equals("replace"))
                {
                    retVal = await responsesManager.UpdateResponseAsync(value, respondentid, questionid);
                }
                else
                    return BadRequest();
            }

            if (retVal == true)
                return Ok();
            else
                return BadRequest();
        }

    }
}

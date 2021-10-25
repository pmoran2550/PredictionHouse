using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTM.PHDomain;
using PTM.Questions;
using PTM.PredictionHouseDB;
using PTM.PHDomain.API_Data_Model;

namespace PTM.PredictionHouseBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : BaseController
    {
        public QuestionsController(PredictionHouseContext dbContext):base(dbContext)
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionListItem>>> GetAsync()
        {
            var allQuestions = await questionManager.GetAllQuestionsAsync();
            return Ok(allQuestions);
        }

        [HttpGet("year/{year}")]
        public async Task<ActionResult<IEnumerable<QuestionListItem>>> GetQuestionsByYear(int year)
        {
            var yearQuestions = await questionManager.GetQuestionsByYearAsync(year);
            return Ok(yearQuestions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PredictionHouseDB.Questions>> GetQuestionByID(int id)
        {
            PredictionHouseDB.Questions question = await questionManager.GetQuestionByIDAsync(id);
            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<PredictionHouseDB.Questions>> PostQuestion(PredictionHouseDB.Questions newQuestion)
        {
            PredictionHouseDB.Questions addedQ = await questionManager.AddQuestion(newQuestion);

            if (addedQ != null)
            {
                string uriStr = "api/questions/" + addedQ.QuestionId.ToString();
                return Created(uriStr, addedQ);
            }
            else
                return BadRequest();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] PatchInstructions data, string id)
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
                    retVal = await questionManager.UpdateQuestionAnswerAsync(value, id);
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
 
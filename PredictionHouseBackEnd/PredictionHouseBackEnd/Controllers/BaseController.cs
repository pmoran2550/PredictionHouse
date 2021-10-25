using System;
using Microsoft.AspNetCore.Mvc;
using PTM.Questions;
using PTM.PredictionHouseDB;
using PTM.RespondentLibrary;
using PTM.Responses;

namespace PTM.PredictionHouseBackEnd.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private PredictionHouseContext _dbContext;
        protected QuestionManager questionManager;
        protected RespondentManager respondentManager;
        protected ResponsesManager responsesManager;
        public BaseController(PredictionHouseContext dbContext)
        {
            _dbContext = dbContext;
            questionManager = new QuestionManager(_dbContext);
            respondentManager = new RespondentManager(_dbContext);
            responsesManager = new ResponsesManager(_dbContext);
        }
    }
}

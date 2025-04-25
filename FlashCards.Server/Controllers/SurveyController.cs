using FlashCards.Server.Models.Data;
using FlashCards.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashCards.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        readonly IDataService _dataService;
        public SurveyController(IDataService dataservice) 
        {
            _dataService = dataservice;        
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetSurveysAsync()
        {
            return Ok(await _dataService.GetSurveysAsync());
        }

        // [Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetSurveyAsync(int id)
        {
            Survey? survey = await _dataService.GetSurveyAsync(id);
            ICollection<Question>? questions = await _dataService.GetQuestionsAsync(id);
            if (survey != null && questions != null && questions.Any()) {
                survey.Questions = questions;
            }
 
            return Ok(survey);
            
        }

    }
}

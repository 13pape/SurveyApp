using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Models;
using Microsoft.AspNetCore.Cors;
using System.Collections;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveyApp.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]

    public class SurveyController : Controller
    {
        private SurveyAppContext _context;

        public SurveyController(SurveyAppContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //IQueryable<Survey> survey = from s in _context.Survey
            //select s;

            IQueryable<object> survey = from s in _context.Survey
                                        join que in _context.Question
                                        on s.SurveyId equals que.SurveyId
                                        join ans in _context.Answer
                                        on que.QuestionId equals ans.QuestionId
                                        select new
                                        {
                                            Name = s.Name,
                                            Question = que.QuestionText,
                                            QuestionId = que.QuestionId,
                                            Answer = ans.AnswerText,
                                            AnswerId = ans.AnswerId
                                        };

            if (survey == null)
            {
                return NotFound();
            }

            return Ok(survey);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

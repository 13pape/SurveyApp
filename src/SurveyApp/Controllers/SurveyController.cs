using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Models;
using Microsoft.AspNetCore.Cors;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Analysis;

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

            var surveyList = _context.Survey.ToList();
            var questionList = _context.Question.ToList();
            var answerList = _context.Answer.ToList();

            SurveyTest surveyTest = new SurveyTest
            {
                //TODO:  we're just getting the 1st survey in list
                Survey = surveyList.First(),
                AgeList = _context.Age.ToList(),
                SexList = _context.Sex.ToList()
            };

            return Ok(surveyTest);

            //IQueryable<Survey> survey = from s in _context.Survey
            //select s;

            //IQueryable<SurveyQuestion> surveyList = from s in _context.Survey
            //                                join que in _context.Question
            //                                on s.SurveyId equals que.SurveyId
            //                                join ans in _context.Answer
            //                                on que.QuestionId equals ans.QuestionId
            //                                select new SurveyQuestion
            //                                {
            //                                    SurveyName = s.Name,
            //                                    QuestionText = que.QuestionText,
            //                                    QuestionID = que.QuestionId,
            //                                    AnswerText = ans.AnswerText,
            //                                    AnswerID = ans.AnswerId
            //                                };

            //var surveyList = (from s in _context.Survey
            //                    join que in _context.Question
            //                    on s.SurveyId equals que.SurveyId
            //                    join ans in _context.Answer
            //                    on que.QuestionId equals ans.QuestionId
            //                    group new { s, que, ans } by que.SurveyId into questionGroup
            //                    select questionGroup).ToList();

            //foreach(var survey in surveyList)
            //{
            //    foreach(var item in survey)
            //    {
            //        item.
            //    }
            //}

            //var surveyList = _context.Survey.ToList();
            //var questionList = _context.Question.ToList();
            //var answerList = _context.Answer.ToList();

            //List<SurveyQuestion> surveyQuestions = new List<SurveyQuestion>();
            //foreach(var survey in surveyList)
            //{
            //    foreach(var question in questionList.Where(x => x.SurveyId == survey.SurveyId))
            //    {
            //        SurveyQuestion surveyQuestion = new SurveyQuestion
            //        {
            //            Survey = survey,
            //            Question = question
            //        };
            //        foreach(var answer in answerList.Where(x => x.QuestionId == question.QuestionId))
            //        {
            //            surveyQuestion.Answers.Add(answer);
            //        }
            //        surveyQuestions.Add(surveyQuestion);
            //    }
            //}

            //List<QuestionsAndAnswers> questionAnswerList = new List<QuestionsAndAnswers>();

            //foreach(var survey in _context.Survey)
            //{
            //    foreach(var question in _context.Question.Where(x => x.SurveyId == survey.SurveyId))
            //    {
            //        QuestionsAndAnswers questionAnswers = new QuestionsAndAnswers { SurveyQuestion = question };
            //        foreach(var answer in _context.Answer.Where(x => x.QuestionId == question.QuestionId))
            //        {
            //            questionAnswers.Answers.Add(answer);
            //        }

            //        questionAnswerList.Add(questionAnswers);
            //    }
            //}

            //if (surveyList == null)
            //{
            //    return NotFound();
            //}

            //foreach(var question in survey.QuestionList)
            //{
            //    questionAnswerList.Add(new QuestionsAndAnswers
            //    {
            //        SurveyQuestion = question,
            //        Answers = question.AnswerList.ToList()
            //    });
            //}

            //return Ok(surveyQuestions);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SurveyUser surveyUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //create a new user
            var newUser = _context.SurveyUser.Add(new SurveyUser
            {
                AgeId = surveyUser.AgeId,
                SexId = surveyUser.SexId
            });

            //save the user to the database
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            //iterate through each user answer and set the user ID to the user ID that we got back
            //from the call to save the new user
            foreach(var userAnswer in surveyUser.UserAnswerList)
            {
                userAnswer.SurveyUserId = newUser.Entity.SurveyUserId;
            }
            //add all of these user answers to the useranswer repository
            _context.UserAnswer.AddRange(surveyUser.UserAnswerList);

            //save the changes to the database
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            var analysis = new SurveyAnalysis(_context);
            var results = analysis.GetGeneralResults();

            //return something!!!
            return Ok(results);
            
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

        //private List<string> TestAnalysis()
        //{
        //    List<string> results = new List<string>();
        //    var answers = _context.Answer.ToList();
        //    foreach(var answer in answers)
        //    {
                
        //    }

        //    return results;
        //}
    }
}

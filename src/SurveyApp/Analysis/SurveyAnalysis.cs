﻿using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Analysis
{
    public class SurveyAnalysis
    {
        private SurveyAppContext _context;

        public SurveyAnalysis(SurveyAppContext context)
        {
            _context = context;
        }
        //create a table so we can build a chart
        public List<AnswerResults> GetResultsGeneral()
        {
            List<AnswerResults> results = new List<AnswerResults>();
            //get all answers from database and group them by the question ID
            var answers = _context.Answer.GroupBy(x => x.QuestionId).ToList();
            //iterate through each of these grouped items
            foreach (var answerGroup in answers)
            {
                //create a new AnswerResults object
                var answerResult = new AnswerResults();
                //iterate through each of the answer groups
                foreach (var answer in answerGroup)
                {
                    answerResult.QuestionId = answer.QuestionId;
                    answerResult.ChosenAnswers.Add(new ChosenAnswer
                    {
                        AnswerId = answer.AnswerId
                    });
                }
            }

            return results;
        }

        public List<AnswerResults> GetGeneralResults()
        {
            var answerResultList = new List<AnswerResults>();

            var answers = _context.Answer.ToList();
            var questions = _context.Question.ToList();
            var userAnswers = _context.UserAnswer.ToList();

            foreach(var question in questions)
            {
                var answerResult = new AnswerResults
                {
                    QuestionId = question.QuestionId,
                    QuestionText = question.QuestionText
                };
                var currentAnswers = answers.Where(x => x.QuestionId == question.QuestionId);
                var currentAnswerIDs = currentAnswers.Select(x => x.AnswerId).ToList();
                double totalAnswersForQuestion = userAnswers.Where(x => currentAnswerIDs.Contains(x.AnswerId)).Count();
                foreach (var answer in currentAnswers)
                {
                    answerResult.ChosenAnswers.Add(new ChosenAnswer
                    {
                        AnswerId = answer.AnswerId,
                        AnswerText = answer.AnswerText, 
                        PercentChosen = userAnswers.Count(x => x.AnswerId == answer.AnswerId) / totalAnswersForQuestion
                    });
                }

                answerResultList.Add(answerResult);
            }

            return answerResultList;


            //var results = from s in _context.Answer
            //              join que in _context.Question on s.QuestionId equals que.QuestionId
            //              join ua in _context.UserAnswer on s.AnswerId equals ua.AnswerId
            //              group new { s, que, ua } by que.QuestionId into userResults
            //              select userResults.ToList();

            //var answerResultList = new List<AnswerResults>();
            //foreach(var result in results)
            //{
            //    var answerResult = new AnswerResults
            //    {
            //        QuestionId = result.First().que.QuestionId,
            //        QuestionText = result.First().que.QuestionText,
            //        ChosenAnswers = new List<ChosenAnswer>()
            //    };
            //    foreach(var item in result.GroupBy(x => x.s.AnswerId))
            //    {
            //        var answers = new ChosenAnswer
            //        {
            //            AnswerId = item.Key,
            //            AnswerText = item.First().s.AnswerText,
            //            PercentChosen = item.Count() / result.Count()
            //        };
            //        answerResult.ChosenAnswers.Add(answers);
            //    }
            //    answerResultList.Add(answerResult);
            //}

            //return answerResultList;
        }
    }
}
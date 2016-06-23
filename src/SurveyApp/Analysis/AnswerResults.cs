using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Analysis
{
    public class AnswerResults
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<ChosenAnswer> ChosenAnswers { get; set; } = new List<ChosenAnswer>();
    }

    public class ChosenAnswer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public string PercentChosen { get; set; }
    }
}

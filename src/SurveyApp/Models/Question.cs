using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public string QuestionText { get; set; }

        public ICollection<Answer> AnswerList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class Sex
    {
        public int SexId { get; set; }
        public string Display { get; set; }

        public ICollection<SurveyUser> SurveyUserList { get; set; }
    }
}

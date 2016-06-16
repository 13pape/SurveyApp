using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class SurveyAppContext: DbContext
    {
        public SurveyAppContext(DbContextOptions<SurveyAppContext> options)
            : base(options)
        { }

        public DbSet<Survey> Survey { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<SurveyUser> SurveyUser { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }
        public DbSet<Age> Age { get; set; }
        public DbSet<Sex> Sex { get; set; }
    }
}

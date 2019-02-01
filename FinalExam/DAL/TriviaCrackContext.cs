using FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalExam.DAL
{
    public class TriviaCrackContext : DbContext
    {
        public TriviaCrackContext() : base("TriviaCrackContext")
        {

        }

        public DbSet<Users> Userss { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<QuestionsAnswered> QuestionsAnswereds { get; set; }


    }
}
using FinalExam.DAL;
using FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalExam.Controllers
{
    public class HomeController : Controller
    {
        //Author: Nick Mahe
        //Description: Final Exam

        public static Users myCurrentUser = new Users();
        private TriviaCrackContext db = new TriviaCrackContext();

        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {


            String username = form["Username"].ToString();
            String password = form["Password"].ToString();

            var currentUser = db.Database.SqlQuery<Users>(
            "Select * " +
            "FROM Users " +
            "WHERE UserName = '" + username + "' AND " +
            "UserPassword = '" + password + "'");

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                myCurrentUser.UserName = username;
                myCurrentUser.UserPassword = password;
                var role = db.Database.SqlQuery<Users>(
                "Select * " +
                "FROM Users " +
                "WHERE UserName = '" + username + "' AND " +
                "UserPassword = '" + password + "'").FirstOrDefault();
                myCurrentUser.UserRole = role.UserRole.ToString();


                return RedirectToAction("Index", "Home", new { userlogin = username });
            }
            else
            {
                return View();
            }

            


        }

        [Authorize]
        public ActionResult Play()
        {
            var questionsUnanswered = db.Database.SqlQuery<Question>(
                "Select * " +
                "From Question inner join QuestionsAnswered " +
                "on Question.QuestionID = QuestionsAnswered.QuestionID " +
                "Where QuestionsAnswered.Answered != 1; ");

            return View(questionsUnanswered.ToList());
            
        }

        public ActionResult Answer(int id)
        {
            var questionsToAnswer = db.Database.SqlQuery<Question>(
                   "Select * " +
                   "From Question " +
                   "Where QuestionID = " + id + "; ").FirstOrDefault();
            ViewBag.QuestionID = questionsToAnswer.QuestionID;

            return View(questionsToAnswer);
        }

        [HttpPost]
        public ActionResult Answer(int? id, int questID )
        {
            db.Database.ExecuteSqlCommand(
                "Update QuestionsAnswered " +
                "Set(UserID, QuestionID, Answered) " +
                "Values(" + myCurrentUser.UserID +", " + id + ",  true) " +
                "Where userID = " + myCurrentUser.UserID + " " +
                "And questionID = " + id + "; "
                );


            var response = db.Database.SqlQuery<Question>(
                   "Select * " +
                   "From Question " +
                   "Where QuestionID = " + questID + "; ").FirstOrDefault();
            if (id == response.CorrectAnswer)
            {
                db.Database.ExecuteSqlCommand(
                "Update Users " +
                "Set(UserScore) " +
                "Values(" + myCurrentUser.UserScore + 10 + ") " +
                "Where userID = " + myCurrentUser.UserID + "; "
                    );

            }

            return View("Play");
        }
    }
}
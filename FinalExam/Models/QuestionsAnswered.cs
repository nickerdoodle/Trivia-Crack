using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalExam.Models
{
    [Table("QuestionsAnswered")]
    public class QuestionsAnswered
    {
        [Key]
        public virtual int UserID { get; set; }

        public virtual int QuestionID { get; set; }

        [Required]
        [Display(Name = "Answered")]
        public bool? Answered { get; set; }
    }
}
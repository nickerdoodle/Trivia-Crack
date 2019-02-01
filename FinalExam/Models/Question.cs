using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalExam.Models
{
    [Table("Question")]
    public class Question
    {
        [Key]
        [Display(Name = "Question ID")]
        public int QuestionID { get; set; }

        [Required(ErrorMessage ="Enter a question")]
        [StringLength(200, ErrorMessage = "input exceeds maximum length")]
        [Display(Name = "Question Text")]
        public String QuestionText { get; set; }

        [Required(ErrorMessage = "Enter an answer")]
        [StringLength(50, ErrorMessage = "input exceeds maximum length")]
        [Display(Name = "Answer 1")]
        public String Answer1 { get; set; }

        [Required(ErrorMessage = "Enter an answer")]
        [StringLength(50, ErrorMessage = "input exceeds maximum length")]
        [Display(Name = "Answer 2")]
        public String Answer2 { get; set; }

        [Required(ErrorMessage = "Enter an answer")]
        [StringLength(50, ErrorMessage = "input exceeds maximum length")]
        [Display(Name = "Answer 3")]
        public String Answer3 { get; set; }

        [Required(ErrorMessage = "Enter an answer")]
        [StringLength(50, ErrorMessage = "input exceeds maximum length")]
        [Display(Name = "Answer 4")]
        public String Answer4 { get; set; }

        [Required(ErrorMessage = "Enter a correct answer")]
        [Display(Name ="Correct Answer")]
        public int CorrectAnswer { get; set; }

        public virtual String CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}
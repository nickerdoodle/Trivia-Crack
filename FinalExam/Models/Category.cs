using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalExam.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Display(Name ="Category ID")]
        [StringLength(1,ErrorMessage ="input exceeds max length")]
        public String CategoryID { get; set; }

        [Required(ErrorMessage ="Enter a category description")]
        [Display(Name ="Category Description")]
        [StringLength(20, ErrorMessage ="input exceeds max length")]
        public String CategoryDesc { get; set; }

    }
}
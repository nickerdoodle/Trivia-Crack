using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalExam.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [Display(Name ="User ID")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter user name")]
        [StringLength(20, ErrorMessage = "input exceeds maximum length")]
        [Display(Name = "User Name")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Please enter user password")]
        [StringLength(20, ErrorMessage = "input exceeds maximum length")]
        [Display(Name = "User Password")]
        [DataType(DataType.Password)]
        public String UserPassword { get; set; }

        [Required(ErrorMessage = "Please enter user score")]
        [Display(Name = "User Score")]
        public int UserScore { get; set; }

        [Required(ErrorMessage = "Please enter user role")]
        [StringLength(1, ErrorMessage = "input exceeds maximum length")]
        [Display(Name = "User Role")]
        public String UserRole { get; set; }

    }
}
using Assignment2.Models.CustomValidations;
using Assignment2.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Models
{
    public class Trainer
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "This field is required*")]
        [CustomValidation(typeof(ValidationMethods), "ValidateLength")]
        [CustomValidation(typeof(ValidationMethods), "ValidateFirstCapitalLetter")]
        [MinLength(2, ErrorMessage = "Firstname should have at least 2 characters!")]
        [RegularExpression("^[a-zA-Z]+", ErrorMessage = "Only alphabetical characters allowed!")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "This field is required*")]
        [CustomValidation(typeof(ValidationMethods), "ValidateLength")]
        [CustomValidation(typeof(ValidationMethods), "ValidateFirstCapitalLetter")]
        [MinLength(3, ErrorMessage = "Lastname should have at least 3 characters!")]
        [RegularExpression("^[a-zA-Z]+", ErrorMessage = "Only alphabetical characters allowed!")]
        public string LastName { get; set; }

        [NotMapped]
        public Subject Subject { get; set; }


        [Column("Subject")]
        public string SubjectString
        {
            get { return Subject.ToString(); }
            set { Subject = (Subject)Enum.Parse(typeof(Subject), value, true); }
        }

    }

}
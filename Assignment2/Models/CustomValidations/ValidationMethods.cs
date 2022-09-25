using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models.CustomValidations
{
    public class ValidationMethods
    {
        public static ValidationResult ValidateFirstCapitalLetter(string value, ValidationContext context)
        {
            bool isValid = true;
            if (value != null)
            {
                if (char.IsLower(value[0]))
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"In the field {context.MemberName}, the first letter must be capital!",
                    new List<string> { context.MemberName }); 
            }
        }


        public static ValidationResult ValidateLength(string value, ValidationContext context)
        {
            bool isValid = true;
            if (value != null)
            {
                if (value.Length > 15)
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"In the field {context.MemberName}, up to 15 characters!",
                    new List<string> { context.MemberName }); 
            }
        }

    }
}
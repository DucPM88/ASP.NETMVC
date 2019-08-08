using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNETMVC.Models
{
    public class NumberInStockFrom1To20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock >= 1 && movie.NumberInStock <= 20)
                return ValidationResult.Success;

            else
                return new ValidationResult("NumberInStock required From 1 To 20");
        }
    }
}
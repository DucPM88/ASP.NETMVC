using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNETMVC.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)

                return ValidationResult.Success;
            if (customer.BirthDay == null)
                return new ValidationResult("BirthDay is required");

            var age = DateTime.Today.Year - customer.BirthDay.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 year old to go on a member");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as Customer;
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = (DateTime.Today - customer.BirthDate.Value.Date);
            if (age > TimeSpan.FromDays(18 * 365.2425))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Customer must be at least 18 years old to become a member.");
            }
        }
    }
}
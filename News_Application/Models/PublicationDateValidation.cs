using News_Application.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News_Application.Models
{
    public class PublicationDateValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var news = (News)validationContext.ObjectInstance;
            var day =  news.Publiction_Date.DayOfYear - DateTime.Now.DayOfYear;

            if(day<7&&day>0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date must be From today and a week From today");
            }
       
           

        }
    }
}
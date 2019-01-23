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
            var day =  news.Publiction_Date.Day - DateTime.Now.Day;

            if(day<7)
            {
                return ValidationResult.Success;
            }
            else
            {
                return (new ValidationResult("no no no"));
            }
       
           

        }
    }
}
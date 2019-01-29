
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News_Application.Models
{
    public class author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("Author Name")]
        public string Name { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
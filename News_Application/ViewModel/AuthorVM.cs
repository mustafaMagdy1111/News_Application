using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Application.ViewModel
{
    public class AuthorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
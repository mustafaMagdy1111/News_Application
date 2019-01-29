using News_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Application.ViewModel
{
    public class AuthorViewModel
    {
        public IEnumerable<author> authors { get; set; }
        public IEnumerable<News> news { get; set; }
        public author author { get; set; }
        public News  newss { get; set; }

    }
}
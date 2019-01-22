using News_Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace News_Application.Dto
{
    public class NewsDto
    {
        public int Id { get; set; }

        public string _News { get; set; }

        [DisplayName("Image Url")]
        public string Img_Url { get; set; }

        [DisplayName("Publiction Date")]
        public DateTime Publiction_Date { get; set; }

        [DisplayName("Creation Date")]
        public DateTime Creation_nDate { get; set; }

        public Author author { get; set; }

        public byte authorID { get; set; }

        public IEnumerable<Author> authors { get; set; }
    }
}
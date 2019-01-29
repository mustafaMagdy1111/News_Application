using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace News_Application.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("News")]
        public string _News { get; set; }

        [DisplayName("Image Url")]
        public string Img_Url { get; set; }

   
        [DisplayName("Publiction Date")]
        [PublicationDateValidation]
        public DateTime Publiction_Date { get; set; }

        [DisplayName("Creation Date")]
        public DateTime Creation_nDate { get; set; }

        public author author { get; set; }

        public byte authorID { get; set; }

        public string Title { get; set; }
    }
}
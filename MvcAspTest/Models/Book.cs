using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BootstrapIntroduction.Models
{
    public class Book
    {
        public int id { get; set; }
        public int authorId { get; set; }
        public string title { get; set; }
        public string isbn { get; set; }
        public string synopsis { get; set; }
        public string descritpion { get; set; }
        public string imageUrl { get; set; }
        public virtual Author author { get; set; }
    }
}
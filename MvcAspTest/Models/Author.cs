using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BootstrapIntroduction.Models
{
    public class Author
    {
        [JsonProperty(PropertyName="id")]
        public int id { get; set; }
        
        [Required (ErrorMessage = "{0} is a mandatory field")]
        [JsonProperty(PropertyName = "firstName")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "{0} is a mandatory field")]
        [JsonProperty(PropertyName = "lastName")]
        public string lastName { get; set; }

        [JsonProperty(PropertyName = "biography")]
        public string biography { get; set; }

        [JsonProperty(PropertyName = "books")]
        public virtual ICollection<Book> books { get; set; }
    }
}
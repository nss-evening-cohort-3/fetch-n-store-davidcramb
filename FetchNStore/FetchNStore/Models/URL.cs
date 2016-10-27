using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace FetchNStore.Models
{
    public class URL
    {
        [Key]
        public int URLId { get; set; }
        public string URL_Address { get; set; }
        public int Status_Code { get; set; }
        public int Response_Time { get; set; }
        public string Method { get; set; }
        public DateTime Request_Time { get; set; }
    }

}
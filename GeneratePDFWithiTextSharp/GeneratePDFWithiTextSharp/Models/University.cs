using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneratePDFWithiTextSharp.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public string PrincipalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<Student> Students { get; set; }
    }
}
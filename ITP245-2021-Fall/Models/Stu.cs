using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITP245_2021_Fall.Models
{
    public class Stu
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public double GPA { get; set; }
    }
}
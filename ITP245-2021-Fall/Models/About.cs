using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ITP245_2021_Fall.Models
{
    public class About
    {
        public string AboutPhoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string   Description { get; set; }
        public List<string> Goals { get; set; }
        public List<string> Hobbies { get; set; }
        
        
        
    }
}
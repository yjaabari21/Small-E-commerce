using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        public string Email { get; set; }

        public string Mobile { get; set; }

    }
}
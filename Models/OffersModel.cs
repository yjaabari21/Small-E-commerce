using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class OffersModel
    {
        public int Id { get; set; }
        //public string Location { get; set; }
        
        public string ItemName { get; set; }

        public string ItemDesc { get; set; }
    
        public decimal OldPrice { get; set; }

        public decimal NewPrice { get; set; }
    }
}
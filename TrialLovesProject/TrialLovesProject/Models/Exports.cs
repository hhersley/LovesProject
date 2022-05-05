using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrialLovesProject.Models
{
    public class Exports
    {
        
            public int Id { get; set; }
            public int StoreNumber { get; set; }
            public int Grade { get; set; }
            public decimal PreviousPrice { get; set; }
            public decimal NewPrice { get; set; }
            public decimal PriceDifference { get; set; }
            public System.DateTime TimeStamp { get; set; }

        
        
    }
}
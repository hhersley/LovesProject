//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFLovesProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class StorePrice
    {
        public int Id { get; set; }
        public int StoreNumber { get; set; }
        public int Grade { get; set; }
        public decimal PreviousPrice { get; set; }
        public decimal NewPrice { get; set; }
        public decimal PriceDifference { get; set; }
        public System.DateTime TimeStamp { get; set; }
    
        public virtual Grade Grade1 { get; set; }
        public virtual Store Store { get; set; }
    }
}

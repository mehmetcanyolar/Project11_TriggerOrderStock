//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project11_TriggerOrderStock.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblOrder
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
    
        public virtual TblProduct TblProduct { get; set; }
    }
}

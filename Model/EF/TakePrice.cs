//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class TakePrice
    {
        public int tp_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<double> tp_totalmoney { get; set; }
        public Nullable<System.DateTime> tp_datecreate { get; set; }
        public Nullable<bool> tp_active { get; set; }
    
        public virtual User User { get; set; }
    }
}

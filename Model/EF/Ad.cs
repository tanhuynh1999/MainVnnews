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
    
    public partial class Ad
    {
        public int ads_id { get; set; }
        public string ads_title { get; set; }
        public string ads_poster { get; set; }
        public Nullable<double> ads_money { get; set; }
        public Nullable<int> ads_totalday { get; set; }
        public Nullable<System.DateTime> ads_datecreate { get; set; }
        public Nullable<System.DateTime> ads_dateend { get; set; }
        public Nullable<bool> ads_active { get; set; }
        public Nullable<bool> ads_option { get; set; }
        public Nullable<bool> ads_bin { get; set; }
        public Nullable<int> user_id { get; set; }
    
        public virtual User User { get; set; }
    }
}
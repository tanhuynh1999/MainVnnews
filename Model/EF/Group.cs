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
    
    public partial class Group
    {
        public int group_id { get; set; }
        public Nullable<int> news_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> group_item { get; set; }
        public Nullable<System.DateTime> group_datecreate { get; set; }
        public Nullable<int> category_id { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
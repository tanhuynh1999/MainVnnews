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
    
    public partial class News
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public News()
        {
            this.Reports = new HashSet<Report>();
        }
    
        public int vnew_id { get; set; }
        public string vnew_title { get; set; }
        public string vnew_content { get; set; }
        public Nullable<int> vnew_view { get; set; }
        public Nullable<bool> vnew_active { get; set; }
        public Nullable<bool> vnew_option { get; set; }
        public Nullable<System.DateTime> vnew_datecreate { get; set; }
        public Nullable<System.DateTime> vnew_dateupdate { get; set; }
        public Nullable<int> user_id { get; set; }
        public string vnews_des { get; set; }
        public string vnew_img { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}

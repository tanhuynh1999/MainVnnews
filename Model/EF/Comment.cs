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
    
    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            this.Replys = new HashSet<Reply>();
        }
    
        public int comment_id { get; set; }
        public string comment_content { get; set; }
        public Nullable<System.DateTime> comment_datecreate { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> news_id { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replys { get; set; }
    }
}

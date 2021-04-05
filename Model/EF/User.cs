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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Editors = new HashSet<Editor>();
            this.Groups = new HashSet<Group>();
            this.News = new HashSet<News>();
            this.Replys = new HashSet<Reply>();
            this.Reports = new HashSet<Report>();
            this.Ads = new HashSet<Ad>();
            this.Chats = new HashSet<Chat>();
        }
    
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string user_image { get; set; }
        public string user_phone { get; set; }
        public Nullable<bool> user_active { get; set; }
        public Nullable<bool> user_bin { get; set; }
        public Nullable<System.DateTime> user_datecreate { get; set; }
        public Nullable<System.DateTime> user_dateupdate { get; set; }
        public Nullable<System.DateTime> user_datelogin { get; set; }
        public string user_email { get; set; }
        public Nullable<int> role_id { get; set; }
        public string user_address { get; set; }
        public string user_facebook { get; set; }
        public string user_twiter { get; set; }
        public string user_instagram { get; set; }
        public Nullable<bool> user_sex { get; set; }
        public Nullable<System.DateTime> user_dateofbirth { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Editor> Editors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Groups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ad> Ads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chat> Chats { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace internationalApostille.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class County
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public County()
        {
            this.CountyPaymentMethods = new HashSet<CountyPaymentMethod>();
        }
    
        public int CountyId { get; set; }
        public string CountyName { get; set; }
        public decimal Fee { get; set; }
        public int AroundTime { get; set; }
        public int StateID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Emailform { get; set; }
        public string WorkingHours { get; set; }
        public string POAddress { get; set; }
        public string ClerkName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string LastEditedBy { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public string ZipCode { get; set; }
        public string DepartmentName { get; set; }
        public string Website { get; set; }
    
        public virtual State State { get; set; }
        public virtual ZipCode ZipCode1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CountyPaymentMethod> CountyPaymentMethods { get; set; }
    }
}

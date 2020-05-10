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
    
    public partial class StateOffice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StateOffice()
        {
            this.StateOfficeCarriers = new HashSet<StateOfficeCarrier>();
        }
    
        public int StateOfficeID { get; set; }
        public string DepartmentName { get; set; }
        public bool IsForApostille { get; set; }
        public bool IsForLegalization { get; set; }
        public bool IsMailingAddress { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string WorkingHours { get; set; }
        public string POAddress { get; set; }
        public string PODepartmentName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string LastEditedBy { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public string POZipCodeExtention { get; set; }
        public int StateId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string POZipCode { get; set; }
        public string EmailFormURL { get; set; }
        public string ZipCodeExtention { get; set; }
        public string PhoneExtention { get; set; }
        public string EntityName { get; set; }
    
        public virtual State State { get; set; }
        public virtual ZipCode ZipCode1 { get; set; }
        public virtual ZipCode ZipCode2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StateOfficeCarrier> StateOfficeCarriers { get; set; }
    }
}

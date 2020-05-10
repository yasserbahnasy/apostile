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
    
    public partial class Embassy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Embassy()
        {
            this.EmbassyCarriers = new HashSet<EmbassyCarrier>();
            this.StateCountryJurisdictions = new HashSet<StateCountryJurisdiction>();
        }
    
        public int EmbassyID { get; set; }
        public string EmbassyName { get; set; }
        public bool IsEmbassy { get; set; }
        public int CountryID { get; set; }
        public string ZipCode { get; set; }
        public int AroundTime { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string LastEditedBy { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public string ZipCodeExtention { get; set; }
        public string EmailFormURL { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual ZipCode ZipCode1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmbassyCarrier> EmbassyCarriers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StateCountryJurisdiction> StateCountryJurisdictions { get; set; }
    }
}
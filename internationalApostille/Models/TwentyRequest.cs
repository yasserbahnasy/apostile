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
    
    public partial class TwentyRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TwentyRequest()
        {
            this.TwentyExtraFedexTickets = new HashSet<TwentyExtraFedexTicket>();
        }
    
        public int Id { get; set; }
        public string TrackingIn { get; set; }
        public string TrackingOut { get; set; }
        public byte[] TrackingImageIn { get; set; }
        public byte[] TrackingImageOut { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public string AuthenticationNum { get; set; }
        public string PaidAmount { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<int> ContactInfoId { get; set; }
        public Nullable<bool> IsLegalizationCountry { get; set; }
        public Nullable<int> StatusIdOfTrackingIn { get; set; }
        public Nullable<int> StatusIdOfTrackingOut { get; set; }
        public Nullable<bool> IsFedral { get; set; }
        public Nullable<bool> IsExpedited { get; set; }
        public string InsertedWebURL { get; set; }
    
        public virtual TwentyContactInfoData TwentyContactInfoData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TwentyExtraFedexTicket> TwentyExtraFedexTickets { get; set; }
        public virtual TwentyFedexStatu TwentyFedexStatu { get; set; }
        public virtual TwentyFedexStatu TwentyFedexStatu1 { get; set; }
    }
}
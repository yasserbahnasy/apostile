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
    
    public partial class StateExpeditedFee
    {
        public int StateExpeditedFeeID { get; set; }
        public int Fee { get; set; }
        public int AroundTime { get; set; }
        public string AroundTimeText { get; set; }
        public int StateID { get; set; }
        public bool IsMailing { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string LastEditedBy { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
    
        public virtual State State { get; set; }
    }
}

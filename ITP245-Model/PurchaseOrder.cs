//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITP245_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            this.PoItems = new HashSet<PoItem>();
        }
    
        public int PurchaseOrderNumber { get; set; }
        public int VendorId { get; set; }
        public System.DateTime PoDate { get; set; }
        public decimal Amount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PoItem> PoItems { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}

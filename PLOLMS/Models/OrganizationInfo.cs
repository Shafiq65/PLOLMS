//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PLOLMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrganizationInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrganizationInfo()
        {
            this.OutsideLetterSends = new HashSet<OutsideLetterSend>();
        }
    
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgMobileNo { get; set; }
        public string OrgTelephoneNo { get; set; }
        public string OrgEmail { get; set; }
        public string OrgAddressLine1 { get; set; }
        public string OrgAddressLine2 { get; set; }
        public string OrgAddressLine3 { get; set; }
        public string OrgDesc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutsideLetterSend> OutsideLetterSends { get; set; }
    }
}

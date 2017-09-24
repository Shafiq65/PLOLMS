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
    
    public partial class Designation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Designation()
        {
            this.InsideOfficialRecivers = new HashSet<InsideOfficialReciver>();
            this.LetterArchives = new HashSet<LetterArchive>();
            this.PostingInfoes = new HashSet<PostingInfo>();
            this.OfficeTypeWiseDesignations = new HashSet<OfficeTypeWiseDesignation>();
        }
    
        public int DId { get; set; }
        public string Dname { get; set; }
        public string DesignationCode { get; set; }
        public string DDesc { get; set; }
        public bool IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InsideOfficialReciver> InsideOfficialRecivers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LetterArchive> LetterArchives { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostingInfo> PostingInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfficeTypeWiseDesignation> OfficeTypeWiseDesignations { get; set; }
    }
}

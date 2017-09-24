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
    
    public partial class PostingInfo
    {
        public System.Guid PostingId { get; set; }
        public System.Guid EmplyeeId { get; set; }
        public int OfficeId { get; set; }
        public int DesignationId { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> CellId { get; set; }
        public Nullable<int> SectionId { get; set; }
        public System.DateTime JoiningDate { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public int JobStatusTypeId { get; set; }
        public string PostingDesc { get; set; }
        public bool ISAcrtivePosting { get; set; }
    
        public virtual Cell Cell { get; set; }
        public virtual Depatrment Depatrment { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual EmplyeeBaiscInfo EmplyeeBaiscInfo { get; set; }
        public virtual JobStatusType JobStatusType { get; set; }
        public virtual OfficeInfo OfficeInfo { get; set; }
        public virtual Section Section { get; set; }
    }
}
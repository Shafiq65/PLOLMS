﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PLOLAMSEntities : DbContext
    {
        public PLOLAMSEntities()
            : base("name=PLOLAMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cell> Cells { get; set; }
        public virtual DbSet<Depatrment> Depatrments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<DistrictInfo> DistrictInfoes { get; set; }
        public virtual DbSet<DivisionInfo> DivisionInfoes { get; set; }
        public virtual DbSet<EmplyeeBaiscInfo> EmplyeeBaiscInfoes { get; set; }
        public virtual DbSet<InsideOfficialReciver> InsideOfficialRecivers { get; set; }
        public virtual DbSet<JobStatusType> JobStatusTypes { get; set; }
        public virtual DbSet<LetterArchive> LetterArchives { get; set; }
        public virtual DbSet<LetterAttachment> LetterAttachments { get; set; }
        public virtual DbSet<LetterType> LetterTypes { get; set; }
        public virtual DbSet<OfficeInfo> OfficeInfoes { get; set; }
        public virtual DbSet<OfficeType> OfficeTypes { get; set; }
        public virtual DbSet<OrganizationInfo> OrganizationInfoes { get; set; }
        public virtual DbSet<OutsideLetterSend> OutsideLetterSends { get; set; }
        public virtual DbSet<PostingInfo> PostingInfoes { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<OfficeTypeWiseDesignation> OfficeTypeWiseDesignations { get; set; }
        public virtual DbSet<PersonalLetterReciver> PersonalLetterRecivers { get; set; }
    }
}

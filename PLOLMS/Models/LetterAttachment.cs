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
    
    public partial class LetterAttachment
    {
        public System.Guid LAId { get; set; }
        public System.Guid LetterArchiveId { get; set; }
        public string LAFilePAth { get; set; }
    
        public virtual LetterArchive LetterArchive { get; set; }
    }
}

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
    
    public partial class UserInfo
    {
        public System.Guid USId { get; set; }
        public string UserID { get; set; }
        public string UserPassword { get; set; }
        public System.Guid EmplyeeId { get; set; }
        public int UserTypeId { get; set; }
        public bool USERIsActive { get; set; }
    
        public virtual EmplyeeBaiscInfo EmplyeeBaiscInfo { get; set; }
        public virtual UserType UserType { get; set; }
    }
}

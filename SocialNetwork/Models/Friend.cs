//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Friend
    {
        public int FriendId { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DateConnected { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}

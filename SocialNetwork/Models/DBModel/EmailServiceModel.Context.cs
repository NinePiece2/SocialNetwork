﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialNetwork.Models.DBModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Data.Entity.Core.Objects;

    public partial class EmailServiceEntities : DbContext
    {
        public EmailServiceEntities()
            : base("name=EmailServiceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int EnqueueIncomingMessages(string userName, string title, string createdEmail, string createdName, Nullable<bool> isSecure, string bodyHtml, string messageType, Nullable<bool> isImportantTag, string ccEmail, string bccEmail)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var createdEmailParameter = createdEmail != null ?
                new ObjectParameter("CreatedEmail", createdEmail) :
                new ObjectParameter("CreatedEmail", typeof(string));
    
            var createdNameParameter = createdName != null ?
                new ObjectParameter("CreatedName", createdName) :
                new ObjectParameter("CreatedName", typeof(string));
    
            var isSecureParameter = isSecure.HasValue ?
                new ObjectParameter("IsSecure", isSecure) :
                new ObjectParameter("IsSecure", typeof(bool));
    
            var bodyHtmlParameter = bodyHtml != null ?
                new ObjectParameter("BodyHtml", bodyHtml) :
                new ObjectParameter("BodyHtml", typeof(string));
    
            var messageTypeParameter = messageType != null ?
                new ObjectParameter("MessageType", messageType) :
                new ObjectParameter("MessageType", typeof(string));
    
            var isImportantTagParameter = isImportantTag.HasValue ?
                new ObjectParameter("IsImportantTag", isImportantTag) :
                new ObjectParameter("IsImportantTag", typeof(bool));
    
            var ccEmailParameter = ccEmail != null ?
                new ObjectParameter("CcEmail", ccEmail) :
                new ObjectParameter("CcEmail", typeof(string));
    
            var bccEmailParameter = bccEmail != null ?
                new ObjectParameter("BccEmail", bccEmail) :
                new ObjectParameter("BccEmail", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EnqueueIncomingMessages", userNameParameter, titleParameter, createdEmailParameter, createdNameParameter, isSecureParameter, bodyHtmlParameter, messageTypeParameter, isImportantTagParameter, ccEmailParameter, bccEmailParameter);
        }
    }
}

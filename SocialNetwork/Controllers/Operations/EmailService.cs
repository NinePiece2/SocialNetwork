using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialNetwork.Models.DBModel;

namespace SocialNetwork.Controllers.Operations
{
    public class EmailService
    {
        public static void SendEmail(string email, string subject, string message)
        {
            EmailServiceEntities emailServiceEntities = new EmailServiceEntities();
            emailServiceEntities.EnqueueIncomingMessages(email, subject, "noreply@romitsagu.com", "noreply", false, message, null, null, null, null);
            emailServiceEntities.SaveChanges();
        }
    }
}
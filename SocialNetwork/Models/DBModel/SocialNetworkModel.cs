using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialNetwork.Models.DBModel;

namespace SocialNetwork.Models.DBModel
{
    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}
    public class SocialNetworkModel : IdentityDbContext<ApplicationUser>
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SocialNetwork.Models.DBModel.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public SocialNetworkModel()
            : base("name=SocialNetworkEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.HasDefaultSchema("Identity");

            builder.Entity<ApplicationUser>().ToTable("Users");

            builder.Entity<IdentityRole>().ToTable("Role");

            builder.Entity<IdentityUserRole>().ToTable("UserRoles");

            builder.Entity<IdentityUserClaim>().ToTable("UserClaims");

            builder.Entity<IdentityUserLogin>().ToTable("UserLogins");

            //builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            //builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        }


        public static SocialNetworkModel Create()
        {
            return new SocialNetworkModel();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}
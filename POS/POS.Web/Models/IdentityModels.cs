using System.Data.Entity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace POS.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, MstUserLogin, MstUserRole, MstUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }

    public class MstUserLogin : IdentityUserLogin<int> { }

    public class MstUserRole : IdentityUserRole<int> { }

    public class MstUserClaim : IdentityUserClaim<int> { }

    public class MstRole : IdentityRole<int, MstUserRole>, IRole<int>
    {
        public MstRole()
        {

        }
        public MstRole(string name)
        {
            Name = name;
        }
        [StringLength(100)]
        public string Desciption { get; set; }
        public Nullable<int> CreatedBy { get; set; }

        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
    }

    public class MstUserStore : UserStore<ApplicationUser, MstRole, int, MstUserLogin, MstUserRole, MstUserClaim>
    {
        public MstUserStore(ApplicationDbContext context): base(context)
        {

        }
    }

    public class MstRoleStore : RoleStore<MstRole,int,MstUserRole>
    {
        public MstRoleStore(ApplicationDbContext context ): base(context)
        {

        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,MstRole,int,MstUserLogin,MstUserRole,MstUserClaim>
    {
        public ApplicationDbContext()
            : base("IdentityConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("MST_USER");
            modelBuilder.Entity<MstRole>().ToTable("MST_ROLE");
            modelBuilder.Entity<MstUserRole>().ToTable("MST_USER_ROLE");
            modelBuilder.Entity<MstUserLogin>().ToTable("MST_USER_LOGIN");
            modelBuilder.Entity<MstUserClaim>().ToTable("MST_USER_CLAIM");
        }

    }
}
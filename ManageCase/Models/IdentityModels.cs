using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ManageCase.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CaseNumber> CaseNumber { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<DocumentSource> DocumentSource { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Facility> Facility { get; set; }
        public DbSet<InternalCaseNumber> InternalCaseNumber { get; set; }
        public DbSet<Principal> Principal { get; set; }
        public DbSet<PrincipalCaseNumberJunction> PrincipalCaseNumberJunction { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserCaseNumberJunction> UserCaseNumberJunction { get; set; }
    }
}
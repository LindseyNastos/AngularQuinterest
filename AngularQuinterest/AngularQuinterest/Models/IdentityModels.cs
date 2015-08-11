using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Collections.Generic;

namespace AngularQuinterest.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }


        public string ImageUrl { get; set; }


        public int NumBoards { get; set; }


        public int NumPins { get; set; }


        public ICollection<Board> Boards { get; set; }


        public ICollection<Pin> Pins { get; set; }


        public ICollection<Comment> Comments { get; set; }


        public ApplicationUser()
        {
            this.Boards = new List<Board>();
            this.Pins = new List<Pin>();
            this.Comments = new List<Comment>();
        }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }


        public IDbSet<Board> Boards { get; set; }
        public IDbSet<Pin> Pins { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Comment> Comments { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
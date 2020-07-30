using AT.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AT.Data.Data
{
    public class ATContext : IdentityDbContext<ATuser, ATRole, string, ATUserClaim, ATUserRole, ATUserLogin, ATRoleClaim, ATUserToken>
    {
        public ATContext(DbContextOptions<ATContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ATuser>().ToTable("ATUser");
            builder.Entity<ATRole>().ToTable("ATRole");
            builder.Entity<ATUserRole>().ToTable("ATUserRole");
            builder.Entity<ATUserClaim>().ToTable("ATUserClaim");
            builder.Entity<ATUserLogin>().ToTable("ATUserLogin");
            builder.Entity<ATUserToken>().ToTable("ATUserToken");
            builder.Entity<ATRoleClaim>().ToTable("ATRoleClaim");
        }
        public virtual DbSet<ATMenu> ATMenu { get; set; }
        public virtual DbSet<ATMenuToUser> ATMenuToUser { get; set; }
        public virtual DbSet<ErrorLogSystem> ErrorLogSystem { get; set; }
        public virtual DbSet<ATPermission> ATPermission { get; set; }
        public virtual DbSet<ATRoleToPermission> ATRoleToPermission { get; set; }
         
    }
}

using LoanApplicationSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LoanApplicationSystem.Infrastructure.Persistence
{
    internal class LoanApplicationSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public LoanApplicationSystemDbContext(DbContextOptions<LoanApplicationSystemDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<User>(entity =>
            //{
            //    entity.Property(e => e.Email).HasMaxLength(50);
            //});
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetLover.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Data.Context
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Member>().HasKey(a => a.Id);
            builder.Entity<Member>().Property(a=>a.Name).IsRequired();
            builder.Entity<Member>().Property(a => a.Profession).IsRequired();
            builder.Entity<Member>().Property(a => a.ImgUrl).IsRequired();

        }
        public DbSet<Member> Members { get; set; }
    }
}

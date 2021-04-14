using AspNetCoreDDD.Domain.Entities;
using AspNetCoreDDD.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDDD.Infrastructure.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext (DbContextOptions<MyContext> options) : base (options)
        {
             
        } 

        protected override void OnModelCreating (ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity> (new UserMap().Configure);
        }
    }
}

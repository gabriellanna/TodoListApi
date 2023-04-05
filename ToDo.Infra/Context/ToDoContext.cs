using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Infra.Mapping;

namespace ToDo.Infra.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base (options)
        {
            
        }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity> (new UserMap().Configure);
            base.OnModelCreating (modelBuilder);
        }
        
    }
}
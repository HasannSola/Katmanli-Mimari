using LAP.ENTITIES;
using Microsoft.EntityFrameworkCore;

namespace LAP.DAL.Concrete
{
   public class LapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Server=(localdb)\MSSQLLocalDB; Database=lapContext; Persist Security Info=True;  MultipleActiveResultSets=True";
            optionsBuilder.UseLazyLoadingProxies(false);//ilişkili olan tabloları datalarını alma
            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Customer
            modelBuilder.Entity<Customer>().Property(p => p.StName)
            .HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(p => p.StDescription)
            .HasMaxLength(2000);
            #endregion

            #region Order 
            modelBuilder.Entity<Order>().Property(p => p.StProductName)
            .HasMaxLength(500);
            modelBuilder.Entity<Order>().Property(p => p.StDescription)
            .HasMaxLength(2000);
            #endregion

            #region
            modelBuilder.Entity<User>().Property(p => p.StUserName)
               .HasMaxLength(200);
            modelBuilder.Entity<User>().Property(p => p.StEmail)
                .HasMaxLength(100);
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
 }

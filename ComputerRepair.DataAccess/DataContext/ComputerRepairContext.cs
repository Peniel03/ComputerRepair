using ComputerRepair.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.DataContext
{
    public class ComputerRepairContext : DbContext 
    {
        public ComputerRepairContext(DbContextOptions<ComputerRepairContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many [User ---> Orders]
            modelBuilder.Entity<User>()
                .HasMany<Order>(s => s.Orders)
                .WithOne(b => b.User)
                .HasForeignKey(c => c.UserId);

            //one to many [Order ---> Reviews]
            modelBuilder.Entity<Order>()
                .HasMany<Review>(s => s.Reviews)
                .WithOne(r => r.Order)
                .HasForeignKey(c => c.OrderId);

            //One to One [Payement ---> Order]
            modelBuilder.Entity<Order>()
                .HasOne<Payement>(s => s.Payement)
                .WithOne(b => b.Order);
          
            //one to many [RepairingType ---> Order]
            modelBuilder.Entity<RepairingType>()
                .HasMany<Order>(s => s.Orders)
                .WithOne(r => r.RepairingType)
                .HasForeignKey(c => c.RepairingTypeId);

            //one to many [RepairingType ---> RepairingTeam]
            modelBuilder.Entity<RepairingType>()
                .HasMany<RepairingTeam>(s => s.RepairingTeams)
                .WithOne(r => r.RepairingType)
                .HasForeignKey(c => c.RepairingTypeId);

            //one to many [RepairingTeam ---> RepairingService]
            modelBuilder.Entity<RepairingTeam>()
                .HasMany<RepairingService>(s => s.RepairingServices)
                .WithOne(r => r.RepairingTeam)
                .HasForeignKey(c => c.RepairingTeamId);
            
            //Fixing decimal values to avoid precision lost
            modelBuilder.Entity<Payement>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<RepairingService>()
               .Property(p => p.ServicePrice)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
               .Property(p => p.UnitPrice)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
               .Property(p => p.TotalPrice)
               .HasColumnType("decimal(18,2)");


        }

        //database Tables 
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payement> Payements { get; set; }
        public DbSet<RepairingType> RepairingTypes { get; set; }
        public DbSet<RepairingTeam> RepairingTeams { get; set; }
        public DbSet<RepairingService> RepairingServices { get; set; }

    }
}

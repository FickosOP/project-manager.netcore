using Microsoft.EntityFrameworkCore;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}

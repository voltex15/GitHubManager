using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Commit> Commits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BKON123\MSSQLSERVER01;Database=GitHubManagerDB;Trusted_Connection=True;");
        }
    }
}

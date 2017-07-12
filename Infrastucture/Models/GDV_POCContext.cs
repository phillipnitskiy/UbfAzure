using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastucture.Models
{
    public partial class GDV_POCContext : DbContext
    {
        public virtual DbSet<Ubf> Ubfs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=tcp:lesebhdev-sqlserver.database.windows.net,1433;Database=GDV_POC;user id=EBHAdmin;password=ebh$1234;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ubf>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.ProducerId).HasDefaultValueSql("0");

                entity.Property(e => e.Status).HasDefaultValueSql("0");
            });
        }
    }
}
using HLInsuranceManagementApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLInsuranceManagementApp.Infrastructure
{
    public class HLIMDataContext : DbContext
    {
        public HLIMDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Borrower> Borrowers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Borrower>(x =>
            {
                x.ToTable("Borrower").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("BorrowerId");
            });
        }
    }
}

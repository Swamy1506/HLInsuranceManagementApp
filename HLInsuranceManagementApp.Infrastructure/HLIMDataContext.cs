using HLInsuranceManagementApp.Domain.Common;
using HLInsuranceManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HLInsuranceManagementApp.Infrastructure
{
    public class HLIMDataContext : DbContext
    {
        public HLIMDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<BuyPolicy> BuyPolicy { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Borrower>().ToTable("Borrower");
            builder.Entity<Property>().ToTable("Property");

            builder.Entity<Bank>().ToTable("Bank");

            builder.Entity<InsuranceCompany>().ToTable("InsuranceCompany");
            builder.Entity<InsurancePolicy>().ToTable("InsurancePolicy");

            builder.Entity<BuyPolicy>().ToTable("BuyPolicy");

            builder.Entity<Loan>().ToTable("Loan");

            builder.Entity<BuyPolicy>()
            .HasKey(o => o.TransactionId);

            builder.Entity<InsuranceCompany>()
            .HasKey(o => o.CompanyId);
            
            builder.Entity<Loan>()
            .HasKey(o => o.LoanId);
            
            builder.Entity<InsurancePolicy>()
            .HasKey(o => o.PolicyId);

            builder.Entity<Borrower>()
                .HasMany<Property>(g => g.Properties)
                .WithOne(s => s.Borrower)
                .HasForeignKey(s => s.BorrowerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BuyPolicy>()
               .HasOne<Loan>(g => g.Loan)
               .WithOne(s => s.BuyPolicy)
               .HasForeignKey<Loan>(s => s.LoanId);

            builder.Entity<InsuranceCompany>()
                .HasMany<InsurancePolicy>(g => g.InsurancePolicies)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

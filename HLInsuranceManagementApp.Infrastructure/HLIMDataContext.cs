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
            builder.Entity<Borrower>(x =>
            {
                x.ToTable("Borrowers").HasKey(k => k.Id);
            });

            builder.Entity<Property>(x =>
            {
                x.ToTable("Properties").HasKey(k => k.Id);
            });
        }

    }
}

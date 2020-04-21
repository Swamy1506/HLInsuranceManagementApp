﻿// <auto-generated />
using System;
using HLInsuranceManagementApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HLInsuranceManagementApp.Infrastructure.Migrations
{
    [DbContext(typeof(HLIMDataContext))]
    partial class HLIMDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Borrower");
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.BuyPolicy", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("PolicyId");

                    b.ToTable("BuyPolicy");
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.InsuranceCompany", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("InsuranceCompany");
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.InsurancePolicy", b =>
                {
                    b.Property<int>("PolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("PremiumAmount")
                        .HasColumnType("int");

                    b.Property<int>("Tenure")
                        .HasColumnType("int");

                    b.HasKey("PolicyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("InsurancePolicy");
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.Loan", b =>
                {
                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("OrginalAmount")
                        .HasColumnType("int");

                    b.Property<int>("OrginalTenure")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("RemainingAmount")
                        .HasColumnType("int");

                    b.Property<int>("RemainingTenure")
                        .HasColumnType("int");

                    b.HasKey("LoanId");

                    b.HasIndex("BankId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.BuyPolicy", b =>
                {
                    b.HasOne("HLInsuranceManagementApp.Domain.Entities.InsurancePolicy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.InsurancePolicy", b =>
                {
                    b.HasOne("HLInsuranceManagementApp.Domain.Entities.InsuranceCompany", "Company")
                        .WithMany("InsurancePolicies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.Loan", b =>
                {
                    b.HasOne("HLInsuranceManagementApp.Domain.Entities.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HLInsuranceManagementApp.Domain.Entities.BuyPolicy", "BuyPolicy")
                        .WithOne("Loan")
                        .HasForeignKey("HLInsuranceManagementApp.Domain.Entities.Loan", "LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HLInsuranceManagementApp.Domain.Entities.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HLInsuranceManagementApp.Domain.Entities.Property", b =>
                {
                    b.HasOne("HLInsuranceManagementApp.Domain.Entities.Borrower", "Borrower")
                        .WithMany("Properties")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HLInsuranceManagementApp.Infrastructure.Migrations
{
    public partial class Initial_CreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Borrower",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrower", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompany",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompany", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    BorrowerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_Borrower_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Borrower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicy",
                columns: table => new
                {
                    PolicyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PremiumAmount = table.Column<int>(nullable: false),
                    Tenure = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicy", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_InsurancePolicy_InsuranceCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "InsuranceCompany",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyPolicy",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<int>(nullable: false),
                    PolicyId = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyPolicy", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_BuyPolicy_InsurancePolicy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "InsurancePolicy",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    LoanId = table.Column<int>(nullable: false),
                    OrginalAmount = table.Column<int>(nullable: false),
                    RemainingAmount = table.Column<int>(nullable: false),
                    OrginalTenure = table.Column<int>(nullable: false),
                    RemainingTenure = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loan_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loan_BuyPolicy_LoanId",
                        column: x => x.LoanId,
                        principalTable: "BuyPolicy",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loan_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyPolicy_PolicyId",
                table: "BuyPolicy",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicy_CompanyId",
                table: "InsurancePolicy",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_BankId",
                table: "Loan",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_PropertyId",
                table: "Loan",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_BorrowerId",
                table: "Property",
                column: "BorrowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "BuyPolicy");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "InsurancePolicy");

            migrationBuilder.DropTable(
                name: "Borrower");

            migrationBuilder.DropTable(
                name: "InsuranceCompany");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Migrations
{
    /// <inheritdoc />
    public partial class Initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseStatus",
                columns: table => new
                {
                    Status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatus", x => x.Status);
                });

            migrationBuilder.CreateTable(
                name: "SeverityLevel",
                columns: table => new
                {
                    Level = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeverityLevel", x => x.Level);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    TimeOfCaseOpen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfCaseClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeOfCaseComment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeverityLevelLevel = table.Column<int>(type: "int", nullable: false),
                    CaseStatusStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_CaseStatus_CaseStatusStatus",
                        column: x => x.CaseStatusStatus,
                        principalTable: "CaseStatus",
                        principalColumn: "Status",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_SeverityLevel_SeverityLevelLevel",
                        column: x => x.SeverityLevelLevel,
                        principalTable: "SeverityLevel",
                        principalColumn: "Level",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "char(13)", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseStatusStatus",
                table: "Cases",
                column: "CaseStatusStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_SeverityLevelLevel",
                table: "Cases",
                column: "SeverityLevelLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CaseId",
                table: "Customers",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "CaseStatus");

            migrationBuilder.DropTable(
                name: "SeverityLevel");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quota.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicleRegistrationNumber = table.Column<string>(type: "text", nullable: true),
                    maxQuota = table.Column<double>(type: "double precision", nullable: true),
                    remainingQuota = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotas");
        }
    }
}

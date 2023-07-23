using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedusermanagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorDirectories",
                schema: "Clinic_Db",
                columns: table => new
                {
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDirectories", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "PatientDirectories",
                schema: "Clinic_Db",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDirectories", x => x.PatientId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorDirectories",
                schema: "Clinic_Db");

            migrationBuilder.DropTable(
                name: "PatientDirectories",
                schema: "Clinic_Db");
        }
    }
}

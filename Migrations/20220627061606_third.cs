using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FindUs",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Doctor",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Department",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(nullable: false),
                    DoctorName = table.Column<string>(nullable: true),
                    DoctorSpecialization = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PatientName = table.Column<string>(nullable: true),
                    PatientGender = table.Column<string>(nullable: true),
                    PatientAge = table.Column<string>(nullable: true),
                    MedicalTest1 = table.Column<string>(nullable: true),
                    MedicalTest2 = table.Column<string>(nullable: true),
                    MedicalTest3 = table.Column<string>(nullable: true),
                    MedicalTest4 = table.Column<string>(nullable: true),
                    Medicine1 = table.Column<string>(nullable: true),
                    Morning1 = table.Column<bool>(nullable: false),
                    Afternoon1 = table.Column<bool>(nullable: false),
                    Evening1 = table.Column<bool>(nullable: false),
                    Medicine2 = table.Column<string>(nullable: true),
                    Morning2 = table.Column<bool>(nullable: false),
                    Afternoon2 = table.Column<bool>(nullable: false),
                    Evening2 = table.Column<bool>(nullable: false),
                    Medicine3 = table.Column<string>(nullable: true),
                    Morning3 = table.Column<bool>(nullable: false),
                    Afternoon3 = table.Column<bool>(nullable: false),
                    Evening3 = table.Column<bool>(nullable: false),
                    Medicine4 = table.Column<string>(nullable: true),
                    Morning4 = table.Column<bool>(nullable: false),
                    Afternoon4 = table.Column<bool>(nullable: false),
                    Evening4 = table.Column<bool>(nullable: false),
                    Medicine5 = table.Column<string>(nullable: true),
                    Morning5 = table.Column<bool>(nullable: false),
                    Afternoon5 = table.Column<bool>(nullable: false),
                    Evening5 = table.Column<bool>(nullable: false),
                    Medicine6 = table.Column<string>(nullable: true),
                    Morning6 = table.Column<bool>(nullable: false),
                    Afternoon6 = table.Column<bool>(nullable: false),
                    Evening6 = table.Column<bool>(nullable: false),
                    Medicine7 = table.Column<string>(nullable: true),
                    Morning7 = table.Column<bool>(nullable: false),
                    Afternoon7 = table.Column<bool>(nullable: false),
                    Evening7 = table.Column<bool>(nullable: false),
                    CheckUpAfterDays = table.Column<int>(nullable: false),
                    PrescriptionAddDate = table.Column<DateTime>(nullable: false),
                    DoctorTiming = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DoctorId",
                table: "Prescription",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.AlterColumn<string>(
                name: "FindUs",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Department",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

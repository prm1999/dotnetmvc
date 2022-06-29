using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class finalupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Medicine3",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Medicine4",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Medicine5",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Medicine6",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Doctor");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Medicine3Id",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Medicine4Id",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Medicine5Id",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Medicine6Id",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Patient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Patient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "Doctor",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Announcements = table.Column<string>(nullable: false),
                    AnnouncementFor = table.Column<string>(nullable: false),
                    End = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    AppointmentDate = table.Column<DateTime>(nullable: true),
                    Problem = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PatientId",
                table: "Reviews",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicine3Id",
                table: "Prescription",
                column: "Medicine3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicine4Id",
                table: "Prescription",
                column: "Medicine4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicine5Id",
                table: "Prescription",
                column: "Medicine5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicine6Id",
                table: "Prescription",
                column: "Medicine6Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorId",
                table: "Patient",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_DoctorId",
                table: "Patient",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicine_Medicine3Id",
                table: "Prescription",
                column: "Medicine3Id",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicine_Medicine4Id",
                table: "Prescription",
                column: "Medicine4Id",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicine_Medicine5Id",
                table: "Prescription",
                column: "Medicine5Id",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicine_Medicine6Id",
                table: "Prescription",
                column: "Medicine6Id",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Patient_PatientId",
                table: "Reviews",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_DoctorId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicine_Medicine3Id",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicine_Medicine4Id",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicine_Medicine5Id",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicine_Medicine6Id",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Patient_PatientId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_PatientId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicine3Id",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicine4Id",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicine5Id",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medicine6Id",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Patient_DoctorId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Medicine3Id",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Medicine4Id",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Medicine5Id",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Medicine6Id",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Doctor");

            migrationBuilder.AddColumn<string>(
                name: "Medicine3",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine4",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine5",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine6",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId");
        }
    }
}

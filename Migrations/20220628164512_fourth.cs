using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambulance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    AmbulanceId = table.Column<string>(nullable: false),
                    AmbulanceStatus = table.Column<string>(nullable: true),
                    AmbulanceDriverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ambulance_AmbulanceDriver_AmbulanceDriverId",
                        column: x => x.AmbulanceDriverId,
                        principalTable: "AmbulanceDriver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ambulance_AmbulanceDriverId",
                table: "Ambulance",
                column: "AmbulanceDriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambulance");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGridInfo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmartGrids",
                columns: table => new
                {
                    SmartGridID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SmartGridInfo = table.Column<string>(nullable: true),
                    SmartGridRegistration = table.Column<string>(nullable: true),
                    TotalProsumersCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartGrids", x => x.SmartGridID);
                });

            migrationBuilder.CreateTable(
                name: "SmartGridProsumers",
                columns: table => new
                {
                    SmartGridProsumerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SmartGridID = table.Column<int>(nullable: false),
                    InstallationsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartGridProsumers", x => x.SmartGridProsumerID);
                    table.ForeignKey(
                        name: "FK_SmartGridProsumers_SmartGrids_SmartGridID",
                        column: x => x.SmartGridID,
                        principalTable: "SmartGrids",
                        principalColumn: "SmartGridID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmartGridProsumers_SmartGridID",
                table: "SmartGridProsumers",
                column: "SmartGridID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmartGridProsumers");

            migrationBuilder.DropTable(
                name: "SmartGrids");
        }
    }
}

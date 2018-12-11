using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsumerInfo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prosumers",
                columns: table => new
                {
                    ProsumerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstallationsID = table.Column<int>(nullable: false),
                    KWhBlocksTotalProduction = table.Column<int>(nullable: false),
                    KWhBlocksTotalConsumed = table.Column<int>(nullable: false),
                    kWhBlocksLastMeterStamp = table.Column<DateTime>(nullable: false),
                    ProsumerCurrencyNowInBlocks = table.Column<int>(nullable: false),
                    ProsumerLastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prosumers", x => x.ProsumerID);
                });

            migrationBuilder.CreateTable(
                name: "ProsumerSmartMeterRecordsLogs",
                columns: table => new
                {
                    ProsumerSmartMeterRecordsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProsumerID = table.Column<int>(nullable: false),
                    InstallationsID = table.Column<int>(nullable: false),
                    KWhBlocksProduced = table.Column<int>(nullable: false),
                    KWhBlocksConsumed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProsumerSmartMeterRecordsLogs", x => x.ProsumerSmartMeterRecordsID);
                    table.ForeignKey(
                        name: "FK_ProsumerSmartMeterRecordsLogs_Prosumers_ProsumerID",
                        column: x => x.ProsumerID,
                        principalTable: "Prosumers",
                        principalColumn: "ProsumerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProsumerSmartMeterRecordsLogs_ProsumerID",
                table: "ProsumerSmartMeterRecordsLogs",
                column: "ProsumerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProsumerSmartMeterRecordsLogs");

            migrationBuilder.DropTable(
                name: "Prosumers");
        }
    }
}

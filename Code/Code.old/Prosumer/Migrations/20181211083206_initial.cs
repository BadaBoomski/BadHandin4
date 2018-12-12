using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prosumer.Migrations
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
                    ExpectedComsumed = table.Column<int>(nullable: false),
                    ExpectedProduced = table.Column<int>(nullable: false),
                    CurrentComsumed = table.Column<int>(nullable: false),
                    CurrentProduced = table.Column<int>(nullable: false),
                    ActualComsumed = table.Column<int>(nullable: false),
                    ActualProduced = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prosumers", x => x.ProsumerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prosumers");
        }
    }
}

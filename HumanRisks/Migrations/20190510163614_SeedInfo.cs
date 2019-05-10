using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanRisks.Migrations
{
    public partial class SeedInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskAssessments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskAssessments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    RiskAssessmentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threats_RiskAssessments_RiskAssessmentId",
                        column: x => x.RiskAssessmentId,
                        principalTable: "RiskAssessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RiskAssessments",
                columns: new[] { "Id", "Latitude", "Longitude", "Title" },
                values: new object[] { "1", 0.10000000000000001, 0.20000000000000001, "Test" });

            migrationBuilder.InsertData(
                table: "RiskAssessments",
                columns: new[] { "Id", "Latitude", "Longitude", "Title" },
                values: new object[] { "2", 3.0, 77.5, "XPPR" });

            migrationBuilder.InsertData(
                table: "RiskAssessments",
                columns: new[] { "Id", "Latitude", "Longitude", "Title" },
                values: new object[] { "3", 4.3099999999999996, 4.2000000000000002, "GP" });

            migrationBuilder.InsertData(
                table: "Threats",
                columns: new[] { "Id", "Level", "RiskAssessmentId", "Title" },
                values: new object[] { "1", 1, "1", "T1" });

            migrationBuilder.InsertData(
                table: "Threats",
                columns: new[] { "Id", "Level", "RiskAssessmentId", "Title" },
                values: new object[] { "2", 0, "1", "T2" });

            migrationBuilder.InsertData(
                table: "Threats",
                columns: new[] { "Id", "Level", "RiskAssessmentId", "Title" },
                values: new object[] { "3", 2, "2", "T3" });

            migrationBuilder.CreateIndex(
                name: "IX_Threats_RiskAssessmentId",
                table: "Threats",
                column: "RiskAssessmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Threats");

            migrationBuilder.DropTable(
                name: "RiskAssessments");
        }
    }
}

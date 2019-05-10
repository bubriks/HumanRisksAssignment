using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanRisks.Migrations
{
    public partial class InitialMigration : Migration
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

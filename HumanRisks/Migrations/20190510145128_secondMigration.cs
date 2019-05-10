using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanRisks.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RiskAssessments",
                columns: new[] { "Id", "Latitude", "Longitude", "Title" },
                values: new object[] { "2", 3.0, 77.5, "XPPR" });

            migrationBuilder.InsertData(
                table: "RiskAssessments",
                columns: new[] { "Id", "Latitude", "Longitude", "Title" },
                values: new object[] { "3", 4.3099999999999996, 4.2000000000000002, "GP" });

            migrationBuilder.UpdateData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Level", "Title" },
                values: new object[] { 0, "T2" });

            migrationBuilder.InsertData(
                table: "Threats",
                columns: new[] { "Id", "Level", "RiskAssessmentId", "Title" },
                values: new object[] { "3", 2, "2", "T3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RiskAssessments",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "RiskAssessments",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Level", "Title" },
                values: new object[] { 1, "T1" });
        }
    }
}

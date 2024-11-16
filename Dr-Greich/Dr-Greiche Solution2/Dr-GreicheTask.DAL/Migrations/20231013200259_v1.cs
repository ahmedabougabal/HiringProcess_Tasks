using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dr_GreicheTask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InsurancePapers_EmployeeId",
                table: "InsurancePapers");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePapers_EmployeeId",
                table: "InsurancePapers",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InsurancePapers_EmployeeId",
                table: "InsurancePapers");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePapers_EmployeeId",
                table: "InsurancePapers",
                column: "EmployeeId");
        }
    }
}

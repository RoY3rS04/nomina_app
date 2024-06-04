using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanillaSalarial.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalarioOrdinario",
                table: "Empleados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SalarioOrdinario",
                table: "Empleados",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

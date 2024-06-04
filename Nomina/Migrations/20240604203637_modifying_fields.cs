using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanillaSalarial.Migrations
{
    /// <inheritdoc />
    public partial class modifying_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "RiesgoLaboral",
                table: "Ingresos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RiesgoLaboral",
                table: "Ingresos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}

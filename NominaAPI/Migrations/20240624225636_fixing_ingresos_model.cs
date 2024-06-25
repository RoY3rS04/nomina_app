using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominaAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixing_ingresos_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "RiesgoLaboral",
                table: "Ingresos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "RiesgoLaboral",
                table: "Ingresos",
                type: "float",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}

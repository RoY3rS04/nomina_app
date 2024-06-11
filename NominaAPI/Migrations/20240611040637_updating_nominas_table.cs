using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominaAPI.Migrations
{
    /// <inheritdoc />
    public partial class updating_nominas_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeduccionesId",
                table: "Nominas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngresosId",
                table: "Nominas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nominas_DeduccionesId",
                table: "Nominas",
                column: "DeduccionesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nominas_IngresosId",
                table: "Nominas",
                column: "IngresosId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nominas_Deducciones_DeduccionesId",
                table: "Nominas",
                column: "DeduccionesId",
                principalTable: "Deducciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nominas_Ingresos_IngresosId",
                table: "Nominas",
                column: "IngresosId",
                principalTable: "Ingresos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nominas_Deducciones_DeduccionesId",
                table: "Nominas");

            migrationBuilder.DropForeignKey(
                name: "FK_Nominas_Ingresos_IngresosId",
                table: "Nominas");

            migrationBuilder.DropIndex(
                name: "IX_Nominas_DeduccionesId",
                table: "Nominas");

            migrationBuilder.DropIndex(
                name: "IX_Nominas_IngresosId",
                table: "Nominas");

            migrationBuilder.DropColumn(
                name: "DeduccionesId",
                table: "Nominas");

            migrationBuilder.DropColumn(
                name: "IngresosId",
                table: "Nominas");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanillaSalarial.Migrations
{
    /// <inheritdoc />
    public partial class modifying_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RUC",
                table: "Empleados",
                newName: "NumeroRUC");

            migrationBuilder.RenameColumn(
                name: "INSS",
                table: "Empleados",
                newName: "NumeroINSS");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRealizacion",
                table: "Nominas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRealizacion",
                table: "Nominas");

            migrationBuilder.RenameColumn(
                name: "NumeroRUC",
                table: "Empleados",
                newName: "RUC");

            migrationBuilder.RenameColumn(
                name: "NumeroINSS",
                table: "Empleados",
                newName: "INSS");
        }
    }
}

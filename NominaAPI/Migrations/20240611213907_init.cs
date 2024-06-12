using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominaAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroRUC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroINSS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTerminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deducciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    SalarioBruto = table.Column<double>(type: "float", nullable: false),
                    Prestamos = table.Column<double>(type: "float", nullable: false),
                    IR = table.Column<double>(type: "float", nullable: false),
                    Anticipos = table.Column<double>(type: "float", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deducciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deducciones_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    SalarioOrdinario = table.Column<double>(type: "float", nullable: false),
                    DiasExtras = table.Column<int>(type: "int", nullable: false),
                    HorasExtras = table.Column<int>(type: "int", nullable: false),
                    RiesgoLaboral = table.Column<double>(type: "float", nullable: false),
                    Nocturnidad = table.Column<bool>(type: "bit", nullable: false),
                    Viatico = table.Column<double>(type: "float", nullable: false),
                    Depreciacion = table.Column<double>(type: "float", nullable: false),
                    Comision = table.Column<double>(type: "float", nullable: false),
                    Bonos = table.Column<double>(type: "float", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresos_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nominas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    IngresosId = table.Column<int>(type: "int", nullable: false),
                    DeduccionesId = table.Column<int>(type: "int", nullable: false),
                    FechaRealizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nominas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nominas_Deducciones_DeduccionesId",
                        column: x => x.DeduccionesId,
                        principalTable: "Deducciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Nominas_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Nominas_Ingresos_IngresosId",
                        column: x => x.IngresosId,
                        principalTable: "Ingresos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deducciones_EmpleadoId",
                table: "Deducciones",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_EmpleadoId",
                table: "Ingresos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nominas_DeduccionesId",
                table: "Nominas",
                column: "DeduccionesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nominas_EmpleadoId",
                table: "Nominas",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nominas_IngresosId",
                table: "Nominas",
                column: "IngresosId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nominas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Deducciones");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace kpi.Migrations
{
    public partial class arreglo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agencia",
                columns: table => new
                {
                    Id_Agencia = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_agencia = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Agencia);
                });

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    Id_Area = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Area = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Area);
                });

            migrationBuilder.CreateTable(
                name: "objetivo",
                columns: table => new
                {
                    id_Objetivo = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_objetivo = table.Column<string>(maxLength: 500, nullable: false),
                    Porcentaje_Objetivo = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_Objetivo);
                },
                comment: "Tabla para registrar objetivos");

            migrationBuilder.CreateTable(
                name: "tiempo",
                columns: table => new
                {
                    Id_Tiempo = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Periodo = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Tiempo);
                });

            migrationBuilder.CreateTable(
                name: "subojetivo_area",
                columns: table => new
                {
                    Id_subobjetivos = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_Area = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_subobjetivos);
                    table.ForeignKey(
                        name: "Id_Area_FKK",
                        column: x => x.Id_Area,
                        principalTable: "area",
                        principalColumn: "Id_Area",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 45, nullable: false),
                    Contraseña = table.Column<string>(maxLength: 45, nullable: false),
                    Id_Area = table.Column<int>(type: "int(11)", nullable: false),
                    Usuario_Tipo = table.Column<string>(maxLength: 45, nullable: false),
                    Id_Agencia = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "Id_Agencia",
                        column: x => x.Id_Agencia,
                        principalTable: "agencia",
                        principalColumn: "Id_Agencia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Idarea",
                        column: x => x.Id_Area,
                        principalTable: "area",
                        principalColumn: "Id_Area",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subobjetivos",
                columns: table => new
                {
                    Id_subobjetivos = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Subobjetivo = table.Column<string>(maxLength: 45, nullable: false),
                    Id_Area = table.Column<int>(type: "int(11)", nullable: false),
                    Id_Objetivo = table.Column<int>(type: "int(11)", nullable: false),
                    SubObjetivo = table.Column<string>(name: "% SubObjetivo", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_subobjetivos);
                    table.ForeignKey(
                        name: "Id_Area",
                        column: x => x.Id_Area,
                        principalTable: "area",
                        principalColumn: "Id_Area",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Id_Objetivo",
                        column: x => x.Id_Objetivo,
                        principalTable: "objetivo",
                        principalColumn: "id_Objetivo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(nullable: true),
                    JwtId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: true),
                    Id_Usuario = table.Column<int>(nullable: false),
                    UserIdUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokens", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_tokens_usuario_UserIdUsuario",
                        column: x => x.UserIdUsuario,
                        principalTable: "usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "indicadores",
                columns: table => new
                {
                    Id_CodigoIndiador = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_subobjetivos = table.Column<int>(type: "int(11)", nullable: false),
                    Nombre_Indicador = table.Column<string>(maxLength: 255, nullable: false),
                    Proceso = table.Column<string>(maxLength: 225, nullable: false),
                    Formula = table.Column<string>(maxLength: 245, nullable: false),
                    Detalle = table.Column<string>(maxLength: 245, nullable: false),
                    Id_Tiempo = table.Column<int>(type: "int(11)", nullable: false),
                    Estado = table.Column<string>(maxLength: 75, nullable: false),
                    Responsables = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_CodigoIndiador);
                    table.ForeignKey(
                        name: "Id_subobjetivos",
                        column: x => x.Id_subobjetivos,
                        principalTable: "subobjetivos",
                        principalColumn: "Id_subobjetivos",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Id_Tiempo",
                        column: x => x.Id_Tiempo,
                        principalTable: "tiempo",
                        principalColumn: "Id_Tiempo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "area_agencia",
                columns: table => new
                {
                    Id_Area_Agencia = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_Area = table.Column<int>(type: "int(11)", nullable: false),
                    Id_Agencia = table.Column<int>(type: "int(11)", nullable: false),
                    Id_CodigoIndiador = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Area_Agencia);
                    table.ForeignKey(
                        name: "Id_Agencia_FK",
                        column: x => x.Id_Agencia,
                        principalTable: "agencia",
                        principalColumn: "Id_Agencia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Id_Area_FK",
                        column: x => x.Id_Area,
                        principalTable: "area",
                        principalColumn: "Id_Area",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Id_CodigoIndiador_FK",
                        column: x => x.Id_CodigoIndiador,
                        principalTable: "indicadores",
                        principalColumn: "Id_CodigoIndiador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "logrado",
                columns: table => new
                {
                    Id_CodigoIndiador = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_Area_Agencia = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Meta = table.Column<string>(maxLength: 50, nullable: false),
                    Logrado = table.Column<string>(maxLength: 30, nullable: false),
                    Porcentaje_Cumplimiento = table.Column<string>(maxLength: 45, nullable: false),
                    Observacion = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_CodigoIndiador);
                    table.ForeignKey(
                        name: "Id_Area_Agencia",
                        column: x => x.Id_Area_Agencia,
                        principalTable: "area_agencia",
                        principalColumn: "Id_Area_Agencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "meta",
                columns: table => new
                {
                    Id_CodigoIndiador = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id_Area_Agencia = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_CodigoIndiador);
                    table.ForeignKey(
                        name: "Id_Area_Agencia_FK",
                        column: x => x.Id_Area_Agencia,
                        principalTable: "area_agencia",
                        principalColumn: "Id_Area_Agencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Id_Agencia_idx",
                table: "area_agencia",
                column: "Id_Agencia");

            migrationBuilder.CreateIndex(
                name: "Id_Area_idx",
                table: "area_agencia",
                column: "Id_Area");

            migrationBuilder.CreateIndex(
                name: "Id_CodigoIndiador_idx",
                table: "area_agencia",
                column: "Id_CodigoIndiador");

            migrationBuilder.CreateIndex(
                name: "Id_subobjetivos_idx",
                table: "indicadores",
                column: "Id_subobjetivos");

            migrationBuilder.CreateIndex(
                name: "Id_Tiempo_idx",
                table: "indicadores",
                column: "Id_Tiempo");

            migrationBuilder.CreateIndex(
                name: "Id_Area_Agencia_idx",
                table: "logrado",
                column: "Id_Area_Agencia");

            migrationBuilder.CreateIndex(
                name: "Id_Area_Agencia_idx",
                table: "meta",
                column: "Id_Area_Agencia");

            migrationBuilder.CreateIndex(
                name: "Id_Area_idx",
                table: "meta",
                column: "Id_CodigoIndiador");

            migrationBuilder.CreateIndex(
                name: "Id_Area_Agencia_idx1",
                table: "meta",
                columns: new[] { "Id_Area_Agencia", "Id_CodigoIndiador" });

            migrationBuilder.CreateIndex(
                name: "Id_Area_idx",
                table: "subobjetivos",
                column: "Id_Area");

            migrationBuilder.CreateIndex(
                name: "Id_Objetivo_idx",
                table: "subobjetivos",
                column: "Id_Objetivo");

            migrationBuilder.CreateIndex(
                name: "Id_Area_idx",
                table: "subojetivo_area",
                column: "Id_Area");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_UserIdUsuario",
                table: "tokens",
                column: "UserIdUsuario");

            migrationBuilder.CreateIndex(
                name: "ID_Agencia_idx",
                table: "usuario",
                column: "Id_Agencia");

            migrationBuilder.CreateIndex(
                name: "Id_Area_idx",
                table: "usuario",
                column: "Id_Area");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logrado");

            migrationBuilder.DropTable(
                name: "meta");

            migrationBuilder.DropTable(
                name: "subojetivo_area");

            migrationBuilder.DropTable(
                name: "tokens");

            migrationBuilder.DropTable(
                name: "area_agencia");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "indicadores");

            migrationBuilder.DropTable(
                name: "agencia");

            migrationBuilder.DropTable(
                name: "subobjetivos");

            migrationBuilder.DropTable(
                name: "tiempo");

            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "objetivo");
        }
    }
}

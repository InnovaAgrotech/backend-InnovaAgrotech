using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnatAPP.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDeTipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Biografia = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avaliadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliadores_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailsAlternativos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsAlternativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailsAlternativos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ddd = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Nota = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false, defaultValue: 5m),
                    TotalReviews = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nota = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                    Resenha = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Curtidas = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Descurtidas = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IdAvaliador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Avaliadores_IdAvaliador",
                        column: x => x.IdAvaliador,
                        principalTable: "Avaliadores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("03b6e5d5-b98e-4436-9115-2db0220c7381"), "Arados" },
                    { new Guid("3c80cbd3-df45-476b-9bfb-e50d7e89940e"), "Adubadoras" },
                    { new Guid("72476c3f-2a83-4686-94bc-d3b3c9d33c2e"), "Grades" },
                    { new Guid("8c0fc7a1-63d2-40d6-b31c-1c0a741d42b7"), "Colheitadeiras" },
                    { new Guid("9ed18ed4-17ef-4a6a-9e0b-6cbb7eeb88c2"), "Pulverizadores" },
                    { new Guid("a9dcadad-dde9-4d8f-b91a-0e6eb396f582"), "Escarificadores" },
                    { new Guid("ae32fc1f-14e2-470c-aecf-cf52a79d4e4f"), "Tratores" },
                    { new Guid("b1b4d98c-2cc1-4a08-b7d9-baf8403c2a23"), "Semeadeiras" },
                    { new Guid("cad2a5a7-77a6-4b1b-85f0-b643b2489fd3"), "Enxadas Rotativas" },
                    { new Guid("d19c882e-19c0-4395-a2c6-f6a80f5dbb0e"), "Subsoladores" },
                    { new Guid("d86c580e-88e5-42cf-882c-175848229dbf"), "Enfardadoras" },
                    { new Guid("e6e97a8f-dc2f-4a75-a5ff-6f2d2f6a9d02"), "Drones" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliadores_IdUsuario",
                table: "Avaliadores",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailsAlternativos_IdUsuario",
                table: "EmailsAlternativos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_IdUsuario",
                table: "Empresas",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdUsuario",
                table: "Enderecos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdEmpresa",
                table: "Produtos",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdAvaliador",
                table: "Reviews",
                column: "IdAvaliador");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdProduto",
                table: "Reviews",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_IdUsuario",
                table: "Telefones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Nome",
                table: "Usuarios",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailsAlternativos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Avaliadores");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

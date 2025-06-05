using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace eliza2_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIOS_CSHARP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SenhaHash = table.Column<string>(type: "character varying(110)", maxLength: 110, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS_CSHARP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MENSAGENS_CSHARP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    TextoUsuario = table.Column<string>(type: "text", nullable: false),
                    RespostaBot = table.Column<string>(type: "text", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSAGENS_CSHARP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MENSAGENS_CSHARP_USUARIOS_CSHARP_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS_CSHARP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MENSAGENS_CSHARP_UsuarioId",
                table: "MENSAGENS_CSHARP",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_CSHARP_Email",
                table: "USUARIOS_CSHARP",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MENSAGENS_CSHARP");

            migrationBuilder.DropTable(
                name: "USUARIOS_CSHARP");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 132, 200, 32, 16, 119, 180, 143, 166, 116, 136, 207, 198, 5, 162, 203, 162, 215, 180, 2, 164, 91, 48, 201, 248, 76, 74, 242, 155, 201, 71, 1, 140, 173, 249, 81, 127, 220, 82, 33, 228, 92, 36, 104, 9, 161, 97, 163, 83, 64, 64, 172, 84, 197, 155, 254, 119, 92, 177, 200, 124, 252, 234, 190, 143 }, new byte[] { 173, 100, 51, 130, 186, 219, 250, 3, 106, 131, 96, 175, 29, 186, 191, 151, 176, 158, 153, 39, 30, 75, 219, 32, 179, 84, 153, 183, 132, 183, 251, 213, 240, 65, 110, 40, 219, 246, 84, 152, 25, 178, 222, 8, 1, 231, 230, 164, 253, 85, 159, 20, 67, 56, 206, 53, 94, 132, 47, 90, 250, 249, 1, 52, 166, 15, 23, 217, 18, 209, 133, 119, 196, 144, 35, 175, 82, 91, 121, 219, 205, 77, 206, 64, 215, 10, 77, 55, 211, 217, 98, 66, 30, 236, 115, 22, 95, 25, 19, 248, 127, 228, 179, 82, 230, 140, 38, 199, 89, 32, 166, 116, 101, 215, 243, 189, 47, 116, 62, 192, 25, 25, 56, 183, 195, 101, 231, 200 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 69, 111, 201, 189, 138, 203, 99, 201, 238, 206, 113, 91, 19, 57, 232, 99, 137, 158, 2, 197, 181, 242, 112, 200, 198, 173, 156, 238, 253, 255, 53, 175, 222, 116, 26, 94, 216, 159, 186, 29, 82, 88, 248, 56, 51, 228, 88, 124, 39, 39, 224, 232, 81, 67, 190, 137, 57, 196, 41, 35, 9, 147, 189, 175 }, new byte[] { 120, 237, 185, 62, 136, 13, 53, 182, 19, 85, 32, 165, 180, 51, 7, 22, 194, 101, 89, 199, 132, 110, 156, 4, 239, 3, 134, 167, 214, 123, 150, 158, 237, 6, 239, 65, 224, 129, 131, 33, 16, 208, 8, 216, 67, 89, 14, 202, 49, 204, 249, 62, 230, 17, 38, 13, 59, 68, 75, 168, 55, 237, 111, 143, 179, 155, 254, 237, 89, 90, 181, 119, 7, 199, 24, 211, 64, 15, 150, 228, 109, 16, 128, 169, 162, 110, 35, 21, 188, 255, 170, 188, 207, 193, 140, 210, 203, 73, 30, 210, 165, 238, 184, 249, 255, 118, 51, 2, 255, 123, 228, 241, 245, 146, 210, 234, 99, 117, 241, 253, 115, 47, 7, 18, 54, 188, 206, 131 } });
        }
    }
}

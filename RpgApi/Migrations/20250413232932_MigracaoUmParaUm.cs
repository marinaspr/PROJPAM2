using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 69, 111, 201, 189, 138, 203, 99, 201, 238, 206, 113, 91, 19, 57, 232, 99, 137, 158, 2, 197, 181, 242, 112, 200, 198, 173, 156, 238, 253, 255, 53, 175, 222, 116, 26, 94, 216, 159, 186, 29, 82, 88, 248, 56, 51, 228, 88, 124, 39, 39, 224, 232, 81, 67, 190, 137, 57, 196, 41, 35, 9, 147, 189, 175 }, new byte[] { 120, 237, 185, 62, 136, 13, 53, 182, 19, 85, 32, 165, 180, 51, 7, 22, 194, 101, 89, 199, 132, 110, 156, 4, 239, 3, 134, 167, 214, 123, 150, 158, 237, 6, 239, 65, 224, 129, 131, 33, 16, 208, 8, 216, 67, 89, 14, 202, 49, 204, 249, 62, 230, 17, 38, 13, 59, 68, 75, 168, 55, 237, 111, 143, 179, 155, 254, 237, 89, 90, 181, 119, 7, 199, 24, 211, 64, 15, 150, 228, 109, 16, 128, 169, 162, 110, 35, 21, 188, 255, 170, 188, 207, 193, 140, 210, 203, 73, 30, 210, 165, 238, 184, 249, 255, 118, 51, 2, 255, 123, 228, 241, 245, 146, 210, 234, 99, 117, 241, 253, 115, 47, 7, 18, 54, 188, 206, 131 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 125, 129, 148, 111, 161, 43, 137, 206, 242, 221, 170, 196, 229, 29, 64, 218, 125, 106, 101, 20, 124, 242, 78, 48, 38, 31, 255, 205, 247, 214, 209, 190, 37, 60, 140, 119, 165, 165, 134, 220, 59, 52, 200, 10, 184, 229, 252, 170, 11, 41, 104, 65, 134, 85, 249, 67, 27, 185, 95, 72, 240, 87, 192, 84 }, new byte[] { 109, 71, 225, 92, 113, 193, 224, 112, 26, 184, 211, 13, 92, 88, 135, 44, 122, 241, 187, 189, 171, 120, 91, 7, 90, 139, 242, 122, 88, 73, 159, 160, 130, 72, 196, 179, 240, 196, 105, 203, 202, 228, 149, 101, 85, 158, 114, 69, 254, 23, 201, 228, 192, 221, 224, 148, 198, 195, 191, 180, 151, 115, 249, 48, 176, 195, 85, 215, 103, 40, 162, 195, 0, 96, 86, 168, 208, 108, 80, 159, 42, 107, 12, 57, 138, 87, 16, 119, 151, 4, 196, 49, 55, 218, 176, 36, 81, 85, 141, 248, 196, 252, 114, 95, 211, 44, 71, 174, 64, 49, 82, 222, 192, 86, 218, 85, 45, 107, 229, 175, 171, 151, 119, 78, 41, 79, 27, 106 } });
        }
    }
}

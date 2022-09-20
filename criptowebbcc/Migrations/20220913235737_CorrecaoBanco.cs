using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class CorrecaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_clienteid",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Moedas_moedaid",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_contaid",
                table: "Transacoes");

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "moedaid",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_clienteid",
                table: "Contas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Moedas_moedaid",
                table: "Contas",
                column: "moedaid",
                principalTable: "Moedas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_contaid",
                table: "Transacoes",
                column: "contaid",
                principalTable: "Contas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_clienteid",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Moedas_moedaid",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_contaid",
                table: "Transacoes");

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "Transacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "moedaid",
                table: "Contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_clienteid",
                table: "Contas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Moedas_moedaid",
                table: "Contas",
                column: "moedaid",
                principalTable: "Moedas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_contaid",
                table: "Transacoes",
                column: "contaid",
                principalTable: "Contas",
                principalColumn: "id");
        }
    }
}

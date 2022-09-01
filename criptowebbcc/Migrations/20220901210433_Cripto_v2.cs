using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class Cripto_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contas_Clientes_clienteid",
                table: "contas");

            migrationBuilder.DropForeignKey(
                name: "FK_contas_Moedas_moedaid",
                table: "contas");

            migrationBuilder.DropForeignKey(
                name: "FK_transacoes_contas_contaid",
                table: "transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transacoes",
                table: "transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contas",
                table: "contas");

            migrationBuilder.RenameTable(
                name: "transacoes",
                newName: "Transacoes");

            migrationBuilder.RenameTable(
                name: "contas",
                newName: "Contas");

            migrationBuilder.RenameIndex(
                name: "IX_transacoes_contaid",
                table: "Transacoes",
                newName: "IX_Transacoes_contaid");

            migrationBuilder.RenameIndex(
                name: "IX_contas_moedaid",
                table: "Contas",
                newName: "IX_Contas_moedaid");

            migrationBuilder.RenameIndex(
                name: "IX_contas_clienteid",
                table: "Contas",
                newName: "IX_Contas_clienteid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                table: "Contas",
                column: "id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                table: "Contas");

            migrationBuilder.RenameTable(
                name: "Transacoes",
                newName: "transacoes");

            migrationBuilder.RenameTable(
                name: "Contas",
                newName: "contas");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_contaid",
                table: "transacoes",
                newName: "IX_transacoes_contaid");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_moedaid",
                table: "contas",
                newName: "IX_contas_moedaid");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_clienteid",
                table: "contas",
                newName: "IX_contas_clienteid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transacoes",
                table: "transacoes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contas",
                table: "contas",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_contas_Clientes_clienteid",
                table: "contas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_contas_Moedas_moedaid",
                table: "contas",
                column: "moedaid",
                principalTable: "Moedas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transacoes_contas_contaid",
                table: "transacoes",
                column: "contaid",
                principalTable: "contas",
                principalColumn: "id");
        }
    }
}

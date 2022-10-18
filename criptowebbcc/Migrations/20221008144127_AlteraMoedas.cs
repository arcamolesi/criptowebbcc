using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class AlteraMoedas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "capital",
                table: "Moedas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "sigla",
                table: "Moedas",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "var24h",
                table: "Moedas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "var7d",
                table: "Moedas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "vol24",
                table: "Moedas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "voltotal",
                table: "Moedas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "capital",
                table: "Moedas");

            migrationBuilder.DropColumn(
                name: "sigla",
                table: "Moedas");

            migrationBuilder.DropColumn(
                name: "var24h",
                table: "Moedas");

            migrationBuilder.DropColumn(
                name: "var7d",
                table: "Moedas");

            migrationBuilder.DropColumn(
                name: "vol24",
                table: "Moedas");

            migrationBuilder.DropColumn(
                name: "voltotal",
                table: "Moedas");
        }
    }
}

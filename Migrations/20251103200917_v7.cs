using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaPessoal.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Emprestimos",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TempoEmprestimo",
                table: "Emprestimos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Emprestimos");

            migrationBuilder.DropColumn(
                name: "TempoEmprestimo",
                table: "Emprestimos");
        }
    }
}

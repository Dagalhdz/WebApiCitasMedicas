using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCitasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class FixFamiliar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Familiares_Parentescos_ParentescoId",
                table: "Familiares");

            migrationBuilder.AddColumn<int>(
                name: "ParentescoId1",
                table: "Familiares",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Familiares_ParentescoId1",
                table: "Familiares",
                column: "ParentescoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Familiares_Parentescos_ParentescoId",
                table: "Familiares",
                column: "ParentescoId",
                principalTable: "Parentescos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Familiares_Parentescos_ParentescoId1",
                table: "Familiares",
                column: "ParentescoId1",
                principalTable: "Parentescos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Familiares_Parentescos_ParentescoId",
                table: "Familiares");

            migrationBuilder.DropForeignKey(
                name: "FK_Familiares_Parentescos_ParentescoId1",
                table: "Familiares");

            migrationBuilder.DropIndex(
                name: "IX_Familiares_ParentescoId1",
                table: "Familiares");

            migrationBuilder.DropColumn(
                name: "ParentescoId1",
                table: "Familiares");

            migrationBuilder.AddForeignKey(
                name: "FK_Familiares_Parentescos_ParentescoId",
                table: "Familiares",
                column: "ParentescoId",
                principalTable: "Parentescos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Api.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoCreateAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatAt",
                table: "Users",
                newName: "CreateAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Users",
                newName: "CreatAt");
        }
    }
}

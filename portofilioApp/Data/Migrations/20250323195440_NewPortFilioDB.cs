using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portofilioApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewPortFilioDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAccoutn",
                table: "SocialLinks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAccoutn",
                table: "SocialLinks");
        }
    }
}

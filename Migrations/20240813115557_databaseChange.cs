using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperSkillsTracker.Migrations
{
    /// <inheritdoc />
    public partial class databaseChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Experiences",
                newName: "Experience_Title");

            migrationBuilder.AddColumn<string>(
                name: "Skill_Description",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience_Description",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skill_Description",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Experience_Description",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "Experience_Title",
                table: "Experiences",
                newName: "Experience");
        }
    }
}

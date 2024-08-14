using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperSkillsTracker.Migrations
{
    /// <inheritdoc />
    public partial class anotherColumnChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "Skills",
                newName: "Skill_Title");

            migrationBuilder.RenameColumn(
                name: "Certification",
                table: "Certifications",
                newName: "Certification_Title");

            migrationBuilder.AddColumn<string>(
                name: "Certification_Description",
                table: "Certifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certification_Description",
                table: "Certifications");

            migrationBuilder.RenameColumn(
                name: "Skill_Title",
                table: "Skills",
                newName: "Skill");

            migrationBuilder.RenameColumn(
                name: "Certification_Title",
                table: "Certifications",
                newName: "Certification");
        }
    }
}

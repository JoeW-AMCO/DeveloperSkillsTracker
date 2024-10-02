using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperSkillsTracker.Migrations
{
    /// <inheritdoc />
    public partial class generalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "Skills",
                newName: "Skill_Title");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Experiences",
                newName: "Experience_Title");

            migrationBuilder.RenameColumn(
                name: "Certification",
                table: "Certifications",
                newName: "Certification_Title");

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

            migrationBuilder.AddColumn<string>(
                name: "Certification_Description",
                table: "Certifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_FK_User_ID",
                table: "Skills",
                column: "FK_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_FK_User_ID",
                table: "Experiences",
                column: "FK_User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_FK_User_ID",
                table: "Certifications",
                column: "FK_User_ID");

            migrationBuilder.AddForeignKey(
                name: "PK_User_ID_FK_Certification_ID",
                table: "Certifications",
                column: "FK_User_ID",
                principalTable: "Users",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "PK_User_ID_FK_Experience_ID",
                table: "Experiences",
                column: "FK_User_ID",
                principalTable: "Users",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "PK_User_ID_FK_User_ID",
                table: "Skills",
                column: "FK_User_ID",
                principalTable: "Users",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PK_User_ID_FK_Certification_ID",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "PK_User_ID_FK_Experience_ID",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "PK_User_ID_FK_User_ID",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_FK_User_ID",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_FK_User_ID",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Certifications_FK_User_ID",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "Skill_Description",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Experience_Description",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Certification_Description",
                table: "Certifications");

            migrationBuilder.RenameColumn(
                name: "Skill_Title",
                table: "Skills",
                newName: "Skill");

            migrationBuilder.RenameColumn(
                name: "Experience_Title",
                table: "Experiences",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "Certification_Title",
                table: "Certifications",
                newName: "Certification");
        }
    }
}

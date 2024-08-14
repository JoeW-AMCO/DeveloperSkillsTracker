using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperSkillsTracker.Migrations
{
    /// <inheritdoc />
    public partial class newPkFkRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

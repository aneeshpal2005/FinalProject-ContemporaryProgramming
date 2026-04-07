using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProject_ContemporaryProgramming.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HobbiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    TeamMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamMemberBirthdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamMemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamMemberProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamMemberYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.TeamMemberId);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Description", "HobbiesId", "Name" },
                values: new object[,]
                {
                    { 1, "Engaging with written content for pleasure and knowledge.", 1, "Reading" },
                    { 2, "Preparing food for enjoyment and sustenance.", 2, "Cooking" },
                    { 3, "Exploring new places and cultures for leisure.", 3, "Traveling" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "TeamMemberId", "TeamMemberBirthdate", "TeamMemberName", "TeamMemberProgram", "TeamMemberYear" },
                values: new object[,]
                {
                    { 1, "2005-1-1", "Aneesh Palande", "Information Technology", "Pre-Junior" },
                    { 2, "2005-1-1", "Alex Lauffenberger", "CyberSecurity", "Pre-Junior" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}

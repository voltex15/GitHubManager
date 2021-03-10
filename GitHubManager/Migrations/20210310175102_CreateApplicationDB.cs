using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHubManager.Migrations
{
    public partial class CreateApplicationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commits",
                columns: table => new
                {
                    CommitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Repository = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Sha = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Committer = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commits", x => x.CommitId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commits");
        }
    }
}

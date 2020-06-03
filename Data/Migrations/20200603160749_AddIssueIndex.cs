using Microsoft.EntityFrameworkCore.Migrations;

namespace QuakeTrack.Data.Migrations
{
    public partial class AddIssueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueLink");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Issue",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "Issue");

            migrationBuilder.CreateTable(
                name: "IssueLink",
                columns: table => new
                {
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Relation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueLink", x => new { x.ObjectId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_IssueLink_Issue_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueLink_Issue_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueLink_SubjectId",
                table: "IssueLink",
                column: "SubjectId");
        }
    }
}

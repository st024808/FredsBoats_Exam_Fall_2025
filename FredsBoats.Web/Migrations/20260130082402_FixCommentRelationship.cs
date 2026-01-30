using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FredsBoats.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixCommentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BoatId",
                table: "Comments",
                column: "BoatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_boat_BoatId",
                table: "Comments",
                column: "BoatId",
                principalTable: "boat",
                principalColumn: "boatid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_boat_BoatId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BoatId",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.CreateTable(
                name: "BoatComment",
                columns: table => new
                {
                    BoatId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentsCommentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatComment", x => new { x.BoatId, x.CommentsCommentId });
                    table.ForeignKey(
                        name: "FK_BoatComment_Comment_CommentsCommentId",
                        column: x => x.CommentsCommentId,
                        principalTable: "Comment",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoatComment_boat_BoatId",
                        column: x => x.BoatId,
                        principalTable: "boat",
                        principalColumn: "boatid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatComment_CommentsCommentId",
                table: "BoatComment",
                column: "CommentsCommentId");
        }
    }
}

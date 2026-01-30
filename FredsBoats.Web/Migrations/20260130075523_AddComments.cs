using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FredsBoats.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BoatId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatComment");

            migrationBuilder.DropTable(
                name: "Comment");
        }
    }
}

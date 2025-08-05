using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreeappChinmay.Migrations
{
    /// <inheritdoc />
    public partial class TreeStructureSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreeNode",
                columns: table => new
                {
                    NodeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NodeName = table.Column<string>(type: "TEXT", nullable: false),
                    ParentNodeId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeNode", x => x.NodeId);
                    table.ForeignKey(
                        name: "FK_TreeNode_TreeNode_ParentNodeId",
                        column: x => x.ParentNodeId,
                        principalTable: "TreeNode",
                        principalColumn: "NodeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreeNode_ParentNodeId",
                table: "TreeNode",
                column: "ParentNodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeNode");
        }
    }
}

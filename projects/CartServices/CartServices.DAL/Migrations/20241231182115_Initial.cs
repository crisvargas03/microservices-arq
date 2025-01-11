using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartServices.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartSessionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SelectedBook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoppingCartSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSessionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartSessionDetails_ShoppingCartSession_ShoppingCartSessionId",
                        column: x => x.ShoppingCartSessionId,
                        principalTable: "ShoppingCartSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartSessionDetails_ShoppingCartSessionId",
                table: "ShoppingCartSessionDetails",
                column: "ShoppingCartSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartSessionDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartSession");
        }
    }
}

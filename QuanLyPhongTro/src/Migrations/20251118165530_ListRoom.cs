using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongTro.Migrations
{
    /// <inheritdoc />
    public partial class ListRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Person_IdDetail",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_IdBill",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Room");

            migrationBuilder.AddColumn<Guid>(
                name: "IdListRoom",
                table: "Room",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListRoom_Person_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_IdListRoom",
                table: "Room",
                column: "IdListRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdDetail",
                table: "Person",
                column: "IdDetail",
                unique: true,
                filter: "[IdDetail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IdBill",
                table: "BillDetail",
                column: "IdBill",
                unique: true,
                filter: "[IdBill] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListRoom_IdOwner",
                table: "ListRoom",
                column: "IdOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_ListRoom_IdListRoom",
                table: "Room",
                column: "IdListRoom",
                principalTable: "ListRoom",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_ListRoom_IdListRoom",
                table: "Room");

            migrationBuilder.DropTable(
                name: "ListRoom");

            migrationBuilder.DropIndex(
                name: "IX_Room_IdListRoom",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Person_IdDetail",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_IdBill",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "IdListRoom",
                table: "Room");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Room",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdDetail",
                table: "Person",
                column: "IdDetail");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IdBill",
                table: "BillDetail",
                column: "IdBill");
        }
    }
}

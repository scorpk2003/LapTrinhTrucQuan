using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongTro.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRequests");

            migrationBuilder.CreateTable(
                name: "BookingRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdRenter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRoom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesiredStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesiredDurationMonths = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Pending"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BookingRequest__3214EC07", x => x.Id);
                    table.ForeignKey(
                        name: "FK__BookingRequest__IdRenter",
                        column: x => x.IdRenter,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__BookingRequest__IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_IdRenter",
                table: "BookingRequest",
                column: "IdRenter");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_IdRoom",
                table: "BookingRequest",
                column: "IdRoom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRequest");

            migrationBuilder.CreateTable(
                name: "BookingRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRenter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRoom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesiredDurationMonths = table.Column<int>(type: "int", nullable: false),
                    DesiredStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingRequests_Person_IdRenter",
                        column: x => x.IdRenter,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRequests_Room_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_IdRenter",
                table: "BookingRequests",
                column: "IdRenter");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_IdRoom",
                table: "BookingRequests",
                column: "IdRoom");
        }
    }
}

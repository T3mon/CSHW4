using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomStatus = table.Column<int>(type: "int", nullable: false),
                    RoomRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HotelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.Sql(@"
                INSERT INTO Rooms(Id, RoomStatus, RoomRate, HotelId)
                SELECT NEWID(), Hotels.RoomStatus, Hotels.RoomRate, Hotels.Id
                FROM Hotels
                ");

            migrationBuilder.DropColumn(
                name: "RoomRate",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "RoomStatus",
                table: "Hotels");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomStatus",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RoomRate",
                table: "Hotels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            

            migrationBuilder.Sql(@"
                INSERT INTO Hotels(Id, RoomStatus, RoomRate)
                SELECT NEWID(), Rooms.RoomStatus, Rooms.RoomRate
                FROM Rooms
                ");

            


            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

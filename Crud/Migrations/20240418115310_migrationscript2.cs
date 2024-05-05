using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.API.Migrations
{
    public partial class migrationscript2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Usr_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usr_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usr_GenderId = table.Column<int>(type: "int", nullable: false),
                    Usr_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usr_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usr_RoleId = table.Column<int>(type: "int", nullable: false),
                    Usr_isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Usr_Id);
                    table.ForeignKey(
                        name: "FK_tblUsers_tblMasters_Usr_GenderId",
                        column: x => x.Usr_GenderId,
                        principalTable: "tblMasters",
                        principalColumn: "Id"
                        );
                    table.ForeignKey(
                        name: "FK_tblUsers_tblMasters_Usr_RoleId",
                        column: x => x.Usr_RoleId,
                        principalTable: "tblMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_Usr_GenderId",
                table: "tblUsers",
                column: "Usr_GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_Usr_RoleId",
                table: "tblUsers",
                column: "Usr_RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblMasters");
        }
    }
}

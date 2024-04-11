using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.API.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Usr_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usr_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usr_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usr_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usr_Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usr_isActive = table.Column<bool>(type: "bit", nullable: false,defaultValue:true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Usr_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

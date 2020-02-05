using Microsoft.EntityFrameworkCore.Migrations;

namespace PINRezultati.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezultati",
                columns: table => new
                {
                    studId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studMb = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    prezime = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ocjenaKolokvij = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ocjenaProjekt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezultati", x => x.studId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezultati");
        }
    }
}

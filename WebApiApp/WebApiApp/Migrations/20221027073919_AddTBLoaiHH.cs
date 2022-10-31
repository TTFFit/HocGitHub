using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiApp.Migrations
{
    public partial class AddTBLoaiHH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaLoaiHH",
                table: "HangHoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoaiHH",
                columns: table => new
                {
                    MaLoaiHH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiHH = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHH", x => x.MaLoaiHH);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoaiHH",
                table: "HangHoa",
                column: "MaLoaiHH");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_LoaiHH_MaLoaiHH",
                table: "HangHoa",
                column: "MaLoaiHH",
                principalTable: "LoaiHH",
                principalColumn: "MaLoaiHH",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_LoaiHH_MaLoaiHH",
                table: "HangHoa");

            migrationBuilder.DropTable(
                name: "LoaiHH");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_MaLoaiHH",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "MaLoaiHH",
                table: "HangHoa");
        }
    }
}

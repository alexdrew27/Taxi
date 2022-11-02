using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxi",
                columns: table => new
                {
                    TaxiiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: true),
                    Nr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxi", x => x.TaxiiId);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    ComandaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    NrTelefon = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CartierCurent = table.Column<string>(nullable: true),
                    StradaCurenta = table.Column<string>(nullable: true),
                    DetaliiAdresaCurent = table.Column<string>(nullable: true),
                    CartierDestinatie = table.Column<string>(nullable: true),
                    StradaDestinatie = table.Column<string>(nullable: true),
                    DetaliiAdresaDestinatie = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    TaxiiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comenzi_Taxi_TaxiiId",
                        column: x => x.TaxiiId,
                        principalTable: "Taxi",
                        principalColumn: "TaxiiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_TaxiiId",
                table: "Comenzi",
                column: "TaxiiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "Taxi");
        }
    }
}

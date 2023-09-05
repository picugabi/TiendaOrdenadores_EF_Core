using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ComponentesCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Migration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacturaId",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calor = table.Column<double>(type: "float", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FacturaId",
                table: "Pedidos",
                column: "FacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Facturas_FacturaId",
                table: "Pedidos",
                column: "FacturaId",
                principalTable: "Facturas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Facturas_FacturaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_FacturaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "FacturaId",
                table: "Pedidos");
        }
    }
}

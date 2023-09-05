using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ComponentesCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Migration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Facturas_FacturaId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_FacturaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "FacturaId",
                table: "Pedidos");

            migrationBuilder.CreateTable(
                name: "PedidoFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: true),
                    FacturaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoFactura_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidoFactura_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoFactura_FacturaId",
                table: "PedidoFactura",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoFactura_PedidoId",
                table: "PedidoFactura",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoFactura");

            migrationBuilder.AddColumn<int>(
                name: "FacturaId",
                table: "Pedidos",
                type: "int",
                nullable: true);

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
    }
}

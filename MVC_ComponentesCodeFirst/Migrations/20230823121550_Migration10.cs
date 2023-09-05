using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ComponentesCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoFactura_Facturas_FacturaId",
                table: "PedidoFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoFactura_Pedidos_PedidoId",
                table: "PedidoFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoFactura",
                table: "PedidoFactura");

            migrationBuilder.DropIndex(
                name: "IX_PedidoFactura_PedidoId",
                table: "PedidoFactura");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PedidoFactura");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "PedidoFactura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacturaId",
                table: "PedidoFactura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoFactura",
                table: "PedidoFactura",
                columns: new[] { "PedidoId", "FacturaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoFactura_Facturas_FacturaId",
                table: "PedidoFactura",
                column: "FacturaId",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoFactura_Pedidos_PedidoId",
                table: "PedidoFactura",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoFactura_Facturas_FacturaId",
                table: "PedidoFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoFactura_Pedidos_PedidoId",
                table: "PedidoFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoFactura",
                table: "PedidoFactura");

            migrationBuilder.AlterColumn<int>(
                name: "FacturaId",
                table: "PedidoFactura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "PedidoFactura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PedidoFactura",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoFactura",
                table: "PedidoFactura",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoFactura_PedidoId",
                table: "PedidoFactura",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoFactura_Facturas_FacturaId",
                table: "PedidoFactura",
                column: "FacturaId",
                principalTable: "Facturas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoFactura_Pedidos_PedidoId",
                table: "PedidoFactura",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }
    }
}

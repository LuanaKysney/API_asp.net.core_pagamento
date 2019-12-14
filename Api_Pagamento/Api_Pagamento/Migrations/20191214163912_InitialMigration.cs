using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Pagamento.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addressClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    line1 = table.Column<string>(nullable: true),
                    line2 = table.Column<string>(nullable: true),
                    neighborhood = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    postal_code = table.Column<string>(nullable: true),
                    country_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addressClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bandeiras_Cartao_Creditos",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    American_Express = table.Column<string>(nullable: true),
                    Aura = table.Column<string>(nullable: true),
                    Banescard = table.Column<string>(nullable: true),
                    Diners = table.Column<string>(nullable: true),
                    Discover = table.Column<string>(nullable: true),
                    ELO = table.Column<string>(nullable: true),
                    Hipercard = table.Column<string>(nullable: true),
                    JCB = table.Column<string>(nullable: true),
                    Mastercard = table.Column<string>(nullable: true),
                    Visa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bandeiras_Cartao_Creditos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customerClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(nullable: false),
                    taxpayer_id = table.Column<string>(maxLength: 20, nullable: false),
                    email = table.Column<string>(nullable: true),
                    addressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customerClients_addressClients_addressId",
                        column: x => x.addressId,
                        principalTable: "addressClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "json_Boletos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    customerId = table.Column<Guid>(nullable: false),
                    expiration_date = table.Column<DateTime>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    body_instructions = table.Column<string>(nullable: true),
                    on_behalf_of = table.Column<string>(nullable: true),
                    currency = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    payment_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_json_Boletos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_json_Boletos_customerClients_customerId",
                        column: x => x.customerId,
                        principalTable: "customerClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "addressClients",
                columns: new[] { "Id", "city", "country_code", "line1", "line2", "neighborhood", "postal_code", "state" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "Vilarejo", "brasília", "complemento", null, "ceilandia", "72236800", "brasília" });

            migrationBuilder.InsertData(
                table: "customerClients",
                columns: new[] { "Id", "addressId", "email", "first_name", "taxpayer_id" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "testeApi@gmail.com", "Naruto Shippuden ", "09865425555" });

            migrationBuilder.CreateIndex(
                name: "IX_customerClients_addressId",
                table: "customerClients",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_json_Boletos_customerId",
                table: "json_Boletos",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bandeiras_Cartao_Creditos");

            migrationBuilder.DropTable(
                name: "json_Boletos");

            migrationBuilder.DropTable(
                name: "customerClients");

            migrationBuilder.DropTable(
                name: "addressClients");
        }
    }
}

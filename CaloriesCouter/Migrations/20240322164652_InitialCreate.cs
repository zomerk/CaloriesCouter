using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaloriesCouter.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KcalAmmoutPer100g = table.Column<int>(type: "int", nullable: false),
                    ProteinAmmoutPer100g = table.Column<int>(type: "int", nullable: false),
                    FatAmmoutPer100g = table.Column<int>(type: "int", nullable: false),
                    CarbsAmmoutPer100g = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}

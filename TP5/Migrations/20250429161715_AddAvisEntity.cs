using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP5.Migrations
{
    /// <inheritdoc />
    public partial class AddAvisEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "resto");

            migrationBuilder.CreateTable(
                name: "TProprietaire",
                schema: "resto",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailProp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GsmProp = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProprietaire", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "TRestaurant",
                schema: "resto",
                columns: table => new
                {
                    CodeResto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomResto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SpecResto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Tunisienne"),
                    VilleResto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TelResto = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    NumProp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRestaurant", x => x.CodeResto);
                    table.ForeignKey(
                        name: "Relation_Proprio_Restos",
                        column: x => x.NumProp,
                        principalSchema: "resto",
                        principalTable: "TProprietaire",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avis",
                columns: table => new
                {
                    CodeAvis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPersonne = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NumResto = table.Column<int>(type: "int", nullable: false),
                    LeRestoCodeResto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avis", x => x.CodeAvis);
                    table.ForeignKey(
                        name: "FK_Avis_TRestaurant_LeRestoCodeResto",
                        column: x => x.LeRestoCodeResto,
                        principalSchema: "resto",
                        principalTable: "TRestaurant",
                        principalColumn: "CodeResto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avis_LeRestoCodeResto",
                table: "Avis",
                column: "LeRestoCodeResto");

            migrationBuilder.CreateIndex(
                name: "IX_TRestaurant_NumProp",
                schema: "resto",
                table: "TRestaurant",
                column: "NumProp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avis");

            migrationBuilder.DropTable(
                name: "TRestaurant",
                schema: "resto");

            migrationBuilder.DropTable(
                name: "TProprietaire",
                schema: "resto");
        }
    }
}

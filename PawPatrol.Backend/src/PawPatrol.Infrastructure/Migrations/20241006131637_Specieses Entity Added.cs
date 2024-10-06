using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawPatrol.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SpeciesesEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "breed_value",
                schema: "public",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "kind",
                schema: "public",
                table: "pets");

            migrationBuilder.AddColumn<Guid>(
                name: "kind_breed_id",
                schema: "public",
                table: "pets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "kind_species_id",
                schema: "public",
                table: "pets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "species",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "breeds",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    species_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breeds", x => x.id);
                    table.ForeignKey(
                        name: "fk_breeds_species_species_id",
                        column: x => x.species_id,
                        principalSchema: "public",
                        principalTable: "species",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_breeds_species_id",
                schema: "public",
                table: "breeds",
                column: "species_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "breeds",
                schema: "public");

            migrationBuilder.DropTable(
                name: "species",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "kind_breed_id",
                schema: "public",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "kind_species_id",
                schema: "public",
                table: "pets");

            migrationBuilder.AddColumn<string>(
                name: "breed_value",
                schema: "public",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "kind",
                schema: "public",
                table: "pets",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}

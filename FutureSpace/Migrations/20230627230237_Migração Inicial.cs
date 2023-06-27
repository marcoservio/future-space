using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureSpace.Migrations
{
    /// <inheritdoc />
    public partial class MigraçãoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "configurations",
                columns: table => new
                {
                    id_con = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    launch_library_id_con = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_con = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    family_con = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    full_name_con = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    variantt_con = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configurations", x => x.id_con);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "launch_service_providers",
                columns: table => new
                {
                    id_lsp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    url_lsp = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_lsp = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type_lsp = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_launch_service_providers", x => x.id_lsp);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id_loc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    url_loc = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_loc = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country_code_loc = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    map_image_loc = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total_launch_count_loc = table.Column<int>(type: "int", nullable: false),
                    total_landing_count_loc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id_loc);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orbits",
                columns: table => new
                {
                    id_orb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_orb = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abbrev_orb = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orbits", x => x.id_orb);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id_sta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_sta = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id_sta);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rockets",
                columns: table => new
                {
                    id_roc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    configuration_id_roc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rockets", x => x.id_roc);
                    table.ForeignKey(
                        name: "FK_rockets_configurations_configuration_id_roc",
                        column: x => x.configuration_id_roc,
                        principalTable: "configurations",
                        principalColumn: "id_con",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pads",
                columns: table => new
                {
                    id_pad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    url_pad = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    agency_id_pad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_pad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    info_url_pad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    wiki_url_pad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    map_url_pad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    latitude_pad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    longitude_pad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    location_id_pad = table.Column<int>(type: "int", nullable: false),
                    map_image_pad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total_launch_count_pad = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pads", x => x.id_pad);
                    table.ForeignKey(
                        name: "FK_pads_locations_location_id_pad",
                        column: x => x.location_id_pad,
                        principalTable: "locations",
                        principalColumn: "id_loc",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "missions",
                columns: table => new
                {
                    id_mis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    launch_library_id_mis = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_mis = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_mis = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    launch_designator_mis = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type_mis = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    orbit_id_mis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missions", x => x.id_mis);
                    table.ForeignKey(
                        name: "FK_missions_orbits_orbit_id_mis",
                        column: x => x.orbit_id_mis,
                        principalTable: "orbits",
                        principalColumn: "id_orb",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "launchers",
                columns: table => new
                {
                    id_lau = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url_lau = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    launch_library_id_lau = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    slug_lau = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_lau = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status_id_lau = table.Column<int>(type: "int", nullable: false),
                    net_lau = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    window_end_lau = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    window_start_lau = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    inhold_lau = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbdtime_lau = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbddate_lau = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    probability_lau = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    holdreason_lau = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    failreason_lau = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hashtag_lau = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    launch_dervice_provider_id_lau = table.Column<int>(type: "int", nullable: false),
                    rocket_id_lau = table.Column<int>(type: "int", nullable: false),
                    mission_id_lau = table.Column<int>(type: "int", nullable: false),
                    pad_id_lau = table.Column<int>(type: "int", nullable: false),
                    webcast_live_lau = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    image_lau = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    infographic_lau = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    program_lau = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_launchers", x => x.id_lau);
                    table.ForeignKey(
                        name: "FK_launchers_launch_service_providers_launch_dervice_provider_i~",
                        column: x => x.launch_dervice_provider_id_lau,
                        principalTable: "launch_service_providers",
                        principalColumn: "id_lsp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_launchers_missions_mission_id_lau",
                        column: x => x.mission_id_lau,
                        principalTable: "missions",
                        principalColumn: "id_mis",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_launchers_pads_pad_id_lau",
                        column: x => x.pad_id_lau,
                        principalTable: "pads",
                        principalColumn: "id_pad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_launchers_rockets_rocket_id_lau",
                        column: x => x.rocket_id_lau,
                        principalTable: "rockets",
                        principalColumn: "id_roc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_launchers_status_status_id_lau",
                        column: x => x.status_id_lau,
                        principalTable: "status",
                        principalColumn: "id_sta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_launchers_launch_dervice_provider_id_lau",
                table: "launchers",
                column: "launch_dervice_provider_id_lau");

            migrationBuilder.CreateIndex(
                name: "IX_launchers_mission_id_lau",
                table: "launchers",
                column: "mission_id_lau");

            migrationBuilder.CreateIndex(
                name: "IX_launchers_pad_id_lau",
                table: "launchers",
                column: "pad_id_lau");

            migrationBuilder.CreateIndex(
                name: "IX_launchers_rocket_id_lau",
                table: "launchers",
                column: "rocket_id_lau");

            migrationBuilder.CreateIndex(
                name: "IX_launchers_status_id_lau",
                table: "launchers",
                column: "status_id_lau");

            migrationBuilder.CreateIndex(
                name: "IX_missions_orbit_id_mis",
                table: "missions",
                column: "orbit_id_mis");

            migrationBuilder.CreateIndex(
                name: "IX_pads_location_id_pad",
                table: "pads",
                column: "location_id_pad");

            migrationBuilder.CreateIndex(
                name: "IX_rockets_configuration_id_roc",
                table: "rockets",
                column: "configuration_id_roc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "launchers");

            migrationBuilder.DropTable(
                name: "launch_service_providers");

            migrationBuilder.DropTable(
                name: "missions");

            migrationBuilder.DropTable(
                name: "pads");

            migrationBuilder.DropTable(
                name: "rockets");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "orbits");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "configurations");
        }
    }
}

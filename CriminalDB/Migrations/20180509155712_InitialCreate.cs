﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CriminalDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crimes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false),
                    Time = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crimes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Criminals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Height = table.Column<float>(type: "Float", nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(maxLength: 50, nullable: false),
                    Photo = table.Column<string>(maxLength: 250, nullable: false),
                    Weight = table.Column<float>(type: "Float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criminals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Victims",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Height = table.Column<float>(type: "Float", nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(maxLength: 50, nullable: false),
                    Photo = table.Column<string>(maxLength: 250, nullable: false),
                    Weight = table.Column<float>(type: "Float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victims", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CrimeCriminals",
                columns: table => new
                {
                    CrimeID = table.Column<int>(nullable: false),
                    CriminalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeCriminals", x => new { x.CrimeID, x.CriminalID });
                    table.ForeignKey(
                        name: "FK_CrimeCriminals_Crimes_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crimes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrimeCriminals_Criminals_CriminalID",
                        column: x => x.CriminalID,
                        principalTable: "Criminals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrimeVictims",
                columns: table => new
                {
                    CrimeID = table.Column<int>(nullable: false),
                    VictimID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeVictims", x => new { x.CrimeID, x.VictimID });
                    table.ForeignKey(
                        name: "FK_CrimeVictims_Crimes_CrimeID",
                        column: x => x.CrimeID,
                        principalTable: "Crimes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrimeVictims_Victims_VictimID",
                        column: x => x.VictimID,
                        principalTable: "Victims",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeCriminals_CriminalID",
                table: "CrimeCriminals",
                column: "CriminalID");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeVictims_VictimID",
                table: "CrimeVictims",
                column: "VictimID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeCriminals");

            migrationBuilder.DropTable(
                name: "CrimeVictims");

            migrationBuilder.DropTable(
                name: "Criminals");

            migrationBuilder.DropTable(
                name: "Crimes");

            migrationBuilder.DropTable(
                name: "Victims");
        }
    }
}

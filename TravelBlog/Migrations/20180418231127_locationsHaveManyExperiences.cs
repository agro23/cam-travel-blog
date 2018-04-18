using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBlog.Migrations
{
    public partial class locationsHaveManyExperiences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Experiences_ExperienceId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ExperienceId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Experiences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_LocationId",
                table: "Experiences",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Locations_LocationId",
                table: "Experiences",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Locations_LocationId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_LocationId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Experiences");

            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "Locations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ExperienceId",
                table: "Locations",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Experiences_ExperienceId",
                table: "Locations",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "ExperienceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

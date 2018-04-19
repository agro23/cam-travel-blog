using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBlog.Migrations
{
    public partial class AddExperienceIdToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Experiences_ExperienceId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceId",
                table: "People",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Experiences_ExperienceId",
                table: "People",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "ExperienceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
               name: "FK_People_Experiences_ExperienceId",
               table: "People",
               column: "ExperienceId",
               principalTable: "Experiences",
               principalColumn: "ExperienceId",
               onDelete: ReferentialAction.Restrict);

            migrationBuilder.AlterColumn<int>(
                name: "ExperienceId",
                table: "People",
                nullable: true,
                oldClrType: typeof(int));
            
            migrationBuilder.DropForeignKey(
                name: "FK_People_Experiences_ExperienceId",
                table: "People");



           
        }
    }
}

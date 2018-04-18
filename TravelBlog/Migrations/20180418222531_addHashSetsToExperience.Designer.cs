using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelBlog.Models;

namespace TravelBlog.Migrations
{
    [DbContext(typeof(TravelDbContext))]
    [Migration("20180418222531_addHashSetsToExperience")]
    partial class addHashSetsToExperience
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("TravelBlog.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("ExperienceId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("TravelBlog.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Details");

                    b.Property<int?>("ExperienceId");

                    b.Property<string>("Place");

                    b.HasKey("LocationId");

                    b.HasIndex("ExperienceId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TravelBlog.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ExperienceId");

                    b.Property<string>("Name");

                    b.HasKey("PersonId");

                    b.HasIndex("ExperienceId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("TravelBlog.Models.Location", b =>
                {
                    b.HasOne("TravelBlog.Models.Experience")
                        .WithMany("Locations")
                        .HasForeignKey("ExperienceId");
                });

            modelBuilder.Entity("TravelBlog.Models.Person", b =>
                {
                    b.HasOne("TravelBlog.Models.Experience")
                        .WithMany("People")
                        .HasForeignKey("ExperienceId");
                });
        }
    }
}

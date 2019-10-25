﻿// <auto-generated />
using ChristmasAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChristmasAPI.Migrations
{
    [DbContext(typeof(PiContext))]
    partial class PiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("ChristmasAPI.Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ChristmasAPI.Models.Family");
                });

            modelBuilder.Entity("ChristmasAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Exchange");

                    b.Property<int>("Family");

                    b.Property<string>("First")
                        .IsRequired();

                    b.Property<string>("Last")
                        .IsRequired();

                    b.Property<int>("SpouseId");

                    b.HasKey("Id");

                    b.ToTable("ChristmasAPI.Models.User");
                });
#pragma warning restore 612, 618
        }
    }
}

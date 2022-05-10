﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityApplication.Data;

namespace UniversityApplication.Data.Migrations
{
    [DbContext(typeof(UniversityDataContext))]
    [Migration("20220510113125_test38")]
    partial class test38
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("UniversityApplication.Data.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Skopje",
                            Country = "Macedonia",
                            Name = "Vardar",
                            Owner = "Marko"
                        },
                        new
                        {
                            Id = 2,
                            City = "Manchester City",
                            Country = "United Kingdom",
                            Name = "Manchester",
                            Owner = "Dino"
                        },
                        new
                        {
                            Id = 3,
                            City = "Skopje",
                            Country = "Macedonia",
                            Name = "House Of Grappling Arts",
                            Owner = "David"
                        },
                        new
                        {
                            Id = 4,
                            City = "Munich",
                            Country = "Germany",
                            Name = "Bayern",
                            Owner = "Ne znam"
                        },
                        new
                        {
                            Id = 5,
                            City = "Belgrade",
                            Country = "Serbia",
                            Name = "Partizan",
                            Owner = "Ante"
                        });
                });

            modelBuilder.Entity("UniversityApplication.Data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClubId")
                        .HasColumnType("int")
                        .HasColumnName("ClubId");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("Rank")
                        .HasColumnType("int")
                        .HasColumnName("Rank");

                    b.Property<DateTime>("SigningDate")
                        .HasColumnType("datetime")
                        .HasColumnName("SigningDate");

                    b.Property<int>("TotalGoals")
                        .HasColumnType("int")
                        .HasColumnName("TotalGoals");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClubId = 3,
                            DOB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Marko",
                            LastName = "Kolekjeski",
                            Rank = 1,
                            SigningDate = new DateTime(2017, 5, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            TotalGoals = 976124
                        },
                        new
                        {
                            Id = 2,
                            ClubId = 4,
                            DOB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Petar",
                            LastName = "Petkovski",
                            Rank = 5,
                            SigningDate = new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            TotalGoals = 4
                        },
                        new
                        {
                            Id = 3,
                            ClubId = 1,
                            DOB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Hristijan",
                            LastName = "Hristovski",
                            Rank = 2,
                            SigningDate = new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            TotalGoals = 14
                        },
                        new
                        {
                            Id = 4,
                            ClubId = 2,
                            DOB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Marko",
                            LastName = "Markovski",
                            Rank = 3,
                            SigningDate = new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            TotalGoals = 8
                        },
                        new
                        {
                            Id = 5,
                            ClubId = 5,
                            DOB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Simo",
                            LastName = "Hayha",
                            Rank = 4,
                            SigningDate = new DateTime(2017, 5, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            TotalGoals = 14
                        });
                });

            modelBuilder.Entity("UniversityApplication.Data.Entities.Player", b =>
                {
                    b.HasOne("UniversityApplication.Data.Entities.Club", "Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("UniversityApplication.Data.Entities.Club", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}

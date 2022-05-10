
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApplication.Data.Entities;

namespace UniversityApplication.Data
{
    public class UniversityDataContext : DbContext
    {
        private readonly string _connStr;

        public UniversityDataContext()
        {
        }

        public UniversityDataContext(DbContextOptions<UniversityDataContext> options)
        {
#pragma warning disable EF1001 // Internal EF Core API usage.
            SqlServerOptionsExtension sqlServerOptionsExtension = options.FindExtension<SqlServerOptionsExtension>();
#pragma warning restore EF1001 // Internal EF Core API usage.

            if (sqlServerOptionsExtension != null)
            {
                _connStr = sqlServerOptionsExtension.ConnectionString;
            }
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; database = testfinalNODOB; trusted_Connection = True", providerOptions => providerOptions.CommandTimeout(60));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .IsRequired(true);

                entity.Property(e => e.LastName)
                .HasMaxLength(400)
                .IsUnicode(true)
                .IsRequired(true);

                entity.Property(e => e.DOB)
                .HasColumnName("DateOfBirth")
                .HasColumnType("datetime")
                .IsRequired(true);

                entity.Property(e => e.SigningDate)
                .HasColumnName("SigningDate")
                .HasColumnType("datetime")
                .IsRequired(true);

                entity.Property(e => e.Rank)
                .HasColumnName("Rank")
                .HasColumnType("int")
                .IsRequired(true);

                entity.Property(e => e.TotalGoals)
                .HasColumnName("TotalGoals")
                .HasColumnType("int")
                .IsRequired(true);

                entity.Property(e => e.ClubId)
               .HasColumnName("ClubId")
               .HasColumnType("int")
               .IsRequired(true);

                entity.HasOne(e => e.Club);
            });

            modelBuilder.Entity<Player>()
                .HasOne(s => s.Club)
                .WithMany(a => a.Players);


            modelBuilder.Entity<Club>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Name)
                    .HasMaxLength(200)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(a => a.Owner)
                    .HasMaxLength(200)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity.Property(a => a.City)
                    .HasMaxLength(200)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity.Property(a => a.Country)
                    .HasMaxLength(200)
                    .IsUnicode(true)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Club>()
                .HasMany(s => s.Players)
                .WithOne(a => a.Club);

            modelBuilder.Entity<Club>().HasData(
                new Club { Id = 1, Name = "Vardar", Owner = "Marko", City = "Skopje", Country = "Macedonia" },
                new Club { Id = 2, Name = "Manchester", Owner = "Dino", City = "Manchester City", Country = "United Kingdom" },
                new Club { Id = 3, Name = "House Of Grappling Arts", Owner = "David", City = "Skopje", Country = "Macedonia" },
                new Club { Id = 4, Name = "Bayern", Owner = "Ne znam", City = "Munich", Country = "Germany" },
                new Club { Id = 5, Name = "Partizan", Owner = "Ante", City = "Belgrade", Country = "Serbia" }
                );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    FirstName = "Marko",
                    LastName = "Kolekjeski",
                    DOB = DateTime.Today.AddYears(-22), //za dve godini kje bidam roden vo 2002 ama nema da go otvoram ova za dve godini
                    SigningDate = DateTime.Today.AddYears(-5),
                    Rank = 1,
                    TotalGoals = 976124,
                    ClubId = 3

                },
                 new Player
                 {
                     Id = 2,
                     FirstName = "Petar",
                     LastName = "Petkovski",
                     DOB = DateTime.Today.AddYears(-24),
                     SigningDate = DateTime.Today.AddYears(-3),
                     Rank = 5,
                     TotalGoals = 4,
                     ClubId = 4
                 },
               new Player
               {
                   Id = 3,
                   FirstName = "Hristijan",
                   LastName = "Hristovski",
                   DOB = DateTime.Today.AddYears(-20),
                   SigningDate = DateTime.Today.AddYears(-1),
                   Rank = 2,
                   TotalGoals = 14,
                   ClubId = 1
               },
               new Player
               {
                   Id = 4,
                   FirstName = "Marko",
                   LastName = "Markovski",
                   DOB = DateTime.Today.AddYears(-30),
                   SigningDate = DateTime.Today.AddYears(-10),
                   Rank = 3,
                   TotalGoals = 8,
                   ClubId = 2
               },
               new Player
               {
                   Id = 5,
                   FirstName = "Simo",
                   LastName = "Hayha",
                   DOB = DateTime.Today.AddYears(-24),
                   SigningDate = DateTime.Today.AddYears(-5),
                   Rank = 4,
                   TotalGoals = 14,
                   ClubId = 5
               }
                );

        }
    }
}

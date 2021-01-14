using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HsPXL.Models;

namespace HsPXL.Data
{
    public class HsPXLContext : DbContext
    {
        public HsPXLContext (DbContextOptions<HsPXLContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Cursus> Cursus { get; set; }
        public DbSet<HandBoek> HandBoek { get; set; }

        public DbSet<Inschrijving> Inschrijving { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HsPXLContext;Trusted_Connection=True;MultipleActiveResultSets=true;");
        //}


        // Package Manager Console
        // run code below
        // Update-database  

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>().HasData(
        //        new Student
        //        {
        //            StudentID = 1,
        //            Naam = "De Trein",
        //            Voornaam = "Thomas",
        //            Email = "DeTrein@nmbs.be",
        //            CreationDate = DateTime.Now
        //        },
        //            new Student
        //            {
        //                StudentID = 2,
        //                Naam = "John",
        //                Voornaam = "Wick",
        //                Email = "JohnWick@outlook.com",
        //                CreationDate = DateTime.Now
        //            },
        //            new Student
        //            {
        //                StudentID = 3,
        //                Naam = "johnny",
        //                Voornaam = "Deppt",
        //                Email = "JD@gmail.com",
        //                CreationDate = DateTime.Now
        //            }
        //        );

        //    modelBuilder.Entity<HandBoek>().HasData(
        //          new HandBoek
        //          {
        //              HandBoekID = 1,
        //              Title = "Rich Dad Poor Dad",
        //              KostPrijs = 9.99M,
        //              UitgiftDatum = new DateTime(2011, 2, 4),
        //              Afbeelding = "/images/013ce42b-f1f6-4006-ab5f-167fd5815c67_RichdadPoordad.jpg",
        //              CreationDate = DateTime.Now
        //          },
        //          new HandBoek
        //          {
        //              HandBoekID = 2,
        //              Title = "Programmeren in C#",
        //              KostPrijs = 35.88M,
        //              UitgiftDatum = new DateTime(2017, 6, 2),
        //              Afbeelding = "/images/fc90d0c6-e14a-4e5e-aae6-57930530930a_ProgramereninC_Sharp.jpg",
        //              CreationDate = DateTime.Now
        //          },
        //          new HandBoek
        //          {
        //              HandBoekID = 3,
        //              Title = "Programmeren in Jave",
        //              KostPrijs = 40.00M,
        //              UitgiftDatum = new DateTime(2020, 7, 7),
        //              Afbeelding = "/images/11c47c4b-e187-48ce-aa8b-c3c8d9ed3a82_Programmereninjava.jpg",
        //              CreationDate = DateTime.Now
        //          },
        //          new HandBoek
        //          {
        //              HandBoekID = 4,
        //              Title = "Web",
        //              KostPrijs = 10.00M,
        //              UitgiftDatum = new DateTime(2020, 2, 2),
        //              Afbeelding = "/images/410bb993-d35d-4cb5-9be0-5732e57eaac5_WebForDummies.jpg",
        //              CreationDate = DateTime.Now
        //          });
        //    modelBuilder.Entity<Cursus>().HasData(
        //        new Cursus
        //        {
        //            CursusID = 1,
        //            CursusName = "C# Essentails",
        //            Studiepunten = 7,
        //            HandboekID = 2,
        //        },
        //        new Cursus
        //        {
        //            CursusID = 2,
        //            CursusName = "Java Essentails",
        //            Studiepunten = 6,
        //            HandboekID = 3,
        //        });
        //    modelBuilder.Entity<Inschrijving>().HasData(
        //        new Inschrijving
        //        {
        //            InschrijvingID = 1,
        //            StudentID = 1,
        //            CursusID = 1,
        //        },
        //        new Inschrijving
        //        {
        //            InschrijvingID = 2,
        //            StudentID = 1,
        //            CursusID = 2,
        //        },
        //        new Inschrijving
        //        {
        //            InschrijvingID = 3,
        //            StudentID = 2,
        //            CursusID = 1,
        //        });

        //}
    }
}

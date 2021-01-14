using HsPXL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HsPXL.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            HsPXLContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<HsPXLContext>();
            //if (context.Database.GetService<IRelationalDatabaseCreator>().Exists())
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Student.Any())
            {
                context.Student.AddRange(
                   new Student
                   {
                       Naam = "De Trein",
                       Voornaam = "Thomas",
                       Email = "DeTrein@nmbs.be",
                       CreationDate = DateTime.Now
                   },
                   new Student
                   {
                       Naam = "John",
                       Voornaam = "Wick",
                       Email = "JohnWick@outlook.com",
                       CreationDate = DateTime.Now
                   },
                   new Student
                   {
                       Naam = "johnny",
                       Voornaam = "Deppt",
                       Email = "JD@gmail.com",
                       CreationDate = DateTime.Now
                   });
                context.SaveChanges();

            }
            if (!context.HandBoek.Any())
            {
                context.HandBoek.AddRange(
                    new HandBoek
                    {
                        Title = "Rich Dad Poor Dad",
                        KostPrijs = 9.99M,
                        UitgiftDatum = new DateTime(2011, 2, 4),
                        Afbeelding = "/images/013ce42b-f1f6-4006-ab5f-167fd5815c67_RichdadPoordad.jpg",
                        CreationDate = DateTime.Now
                    },
                    new HandBoek
                    {
                        Title = "Programmeren in C#",
                        KostPrijs = 35.88M,
                        UitgiftDatum = new DateTime(2017, 6, 2),
                        Afbeelding = "/images/fc90d0c6-e14a-4e5e-aae6-57930530930a_ProgramereninC_Sharp.jpg",
                        CreationDate = DateTime.Now
                    },
                       new HandBoek
                       {
                           Title = "Programmeren in Jave",
                           KostPrijs = 40.00M,
                           UitgiftDatum = new DateTime(2020, 7, 7),
                           Afbeelding = "/images/11c47c4b-e187-48ce-aa8b-c3c8d9ed3a82_Programmereninjava.jpg",
                           CreationDate = DateTime.Now
                       },
                       new HandBoek
                       {
                           Title = "Web",
                           KostPrijs = 10.00M,
                           UitgiftDatum = new DateTime(2020, 2, 2),
                           Afbeelding = "/images/410bb993-d35d-4cb5-9be0-5732e57eaac5_WebForDummies.jpg",
                           CreationDate = DateTime.Now
                       });
                context.SaveChanges();
            }
            if (!context.Cursus.Any())
            {
                context.Cursus.AddRange(
                   new Cursus
                   {
                       CursusName = "C# Essentails",
                       Studiepunten = 7,
                       HandboekID = 2,
                   },
                   new Cursus
                   {
                       CursusName = "Java Essentails",
                       Studiepunten = 6,
                       HandboekID = 3,
                   });
                context.SaveChanges();
            }
            if(!context.Inschrijving.Any())
            {
              
           
                context.Inschrijving.AddRange(
                    new Inschrijving
                    {
                        StudentID = 1,
                        CursusID = 1,
                    },
                    new Inschrijving
                    {
                        StudentID = 1,
                        CursusID = 2,
                    },
                    new Inschrijving
                    {
                        StudentID = 2,
                        CursusID = 1,
                    });
                context.SaveChanges();
            }
           

        }
    }
}

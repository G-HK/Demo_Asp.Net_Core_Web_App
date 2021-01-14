using HsPXL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HsPXL.Data;

namespace HsPXL.Repositories
{
    public class EFHsRepository : IHsRepository
    {
        private HsPXLContext context;

        public EFHsRepository(HsPXLContext ctt)
        {
            context = ctt;
        }

        public IQueryable<Student> Students => context.Student;

        public IQueryable<Cursus> Cursussen => context.Cursus;

        public IQueryable<HandBoek> HandBoeks => context.HandBoek;

        public IQueryable<Inschrijving> Inschrijvings => context.Inschrijving;
    }
}

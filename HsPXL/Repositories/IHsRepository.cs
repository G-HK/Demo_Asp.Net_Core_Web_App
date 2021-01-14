using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HsPXL.Models;

namespace HsPXL.Repositories
{
    public interface IHsRepository
    {
        IQueryable<Student> Students { get; }
        IQueryable<Cursus> Cursussen { get; }
        IQueryable<HandBoek> HandBoeks { get; }
        IQueryable<Inschrijving> Inschrijvings { get; }

    }
}

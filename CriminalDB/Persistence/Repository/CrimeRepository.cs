﻿using CriminalDB.Core.DataModels;
using CriminalDB.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using CriminalDB.Persistence.Context;

namespace CriminalDB.Persistence.Repository
{
    public class CrimeRepository : GenericRepository<Crime>, ICrimeRepository
    {
        public CrimeRepository(DbContext context) : base(context)
        {

        }
        //TODO: Figure out what it does.
        public CriminalContext CriminalContext
        {
            get { return _context as CriminalContext; }
        }

        public Crime GetCrimeWithCriminals(int id)
        {
            return CriminalContext.Crimes
                .Include(x => x.CrimeCriminals)
                .ThenInclude(x => x.Criminal)
                .Where(x => x.ID == id)
                .SingleOrDefault();
        }

        public Crime GetCrimeWithCriminalsAndVictims(int id)
        {
            return CriminalContext.Crimes
                .Include(x => x.CrimeCriminals)
                .ThenInclude(x => x.Criminal)
                .Include(x => x.CrimeVictims)
                .ThenInclude(x => x.Victim)
                .Where(x => x.ID == id)
                .SingleOrDefault();
        }

        // public IEnumerable<Crime> GetCrimes()
        // {
        //     return CriminalContext.Crimes.ToList();
        // }

        public IEnumerable<Crime> GetCrimesWithCriminals()
        {
            return CriminalContext.Crimes.
                Include(x => x.CrimeCriminals)
                .ThenInclude(x => x.Criminal)
                .OrderBy(x => x.ID)
                .ToList();
        }

        public IEnumerable<Crime> GetCrimesWithCriminalsAndVictims()
        {
            return CriminalContext.Crimes
                .Include(x => x.CrimeCriminals)
                .ThenInclude(x => x.Criminal)
                .Include(x => x.CrimeVictims)
                .ThenInclude(x => x.Victim)
                .OrderBy(x => x.ID)
                .ToList();
        }
    }
}

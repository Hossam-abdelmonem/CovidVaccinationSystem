using CovidVaccinationSystem.Core.Entities;
using CovidVaccinationSystem.Core.Interfaces;
using CovidVaccinationSystem.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationSystem.Data.Repositories
{

    public class VaccinationEntryRepository : IVaccinationEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public VaccinationEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VaccinationEntry>> GetAllAsync()
        {
            return await _context.VaccinationEntries.ToListAsync();
        }

        public async Task<VaccinationEntry> GetByIdAsync(int id)
        {
            return await _context.VaccinationEntries.FindAsync(id);
        }

        public async Task<IEnumerable<VaccinationEntry>> GetByPatientIdAsync(int patientId)
        {
            return await _context.VaccinationEntries
                .Where(ve => ve.PatientId == patientId)
                .ToListAsync();
        }

        public async Task AddAsync(VaccinationEntry vaccinationEntry)
        {
            await _context.VaccinationEntries.AddAsync(vaccinationEntry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VaccinationEntry vaccinationEntry)
        {
            _context.VaccinationEntries.Update(vaccinationEntry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entry = await _context.VaccinationEntries.FindAsync(id);
            if (entry != null)
            {
                _context.VaccinationEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }
        }
    }

}

using CovidVaccinationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationSystem.Core.Interfaces
{
    public interface IVaccinationEntryRepository
    {
        Task<IEnumerable<VaccinationEntry>> GetAllAsync();
        Task<VaccinationEntry> GetByIdAsync(int id);
        Task<IEnumerable<VaccinationEntry>> GetByPatientIdAsync(int patientId);
        Task AddAsync(VaccinationEntry vaccinationEntry);
        Task UpdateAsync(VaccinationEntry vaccinationEntry);
        Task DeleteAsync(int id);
    }
}

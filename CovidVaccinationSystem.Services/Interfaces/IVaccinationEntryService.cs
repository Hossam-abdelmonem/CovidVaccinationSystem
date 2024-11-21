using CovidVaccinationSystem.Core.DTOS;
 

namespace CovidVaccinationSystem.Services.Interfaces
{
    public interface IVaccinationEntryService
    {
        Task<IEnumerable<VaccinationEntryDTO>> GetVaccinationHistoryByPatientIdAsync(int patientId);
        Task<VaccinationEntryDTO> GetVaccinationEntryByIdAsync(int id);
        Task AddVaccinationEntryAsync(VaccinationEntryDTO vaccinationEntryDTO);
        Task DeleteVaccinationEntryAsync(int id);
    }
}

using AutoMapper;
using CovidVaccinationSystem.Core.DTOS;
using CovidVaccinationSystem.Core.Entities;
using CovidVaccinationSystem.Core.Interfaces;
 using CovidVaccinationSystem.Services.Interfaces;
 

namespace CovidVaccinationSystem.Services
{
    public class VaccinationEntryService : IVaccinationEntryService
    {
        private readonly IMapper _mapper;
        private readonly IVaccinationEntryRepository _vaccinationEntryRepository;

        public VaccinationEntryService(IMapper mapper, IVaccinationEntryRepository vaccinationEntryRepository)
        {
            _mapper = mapper;
            _vaccinationEntryRepository = vaccinationEntryRepository;
        }

        // Get Vaccination history for a specific patient
        public async Task<IEnumerable<VaccinationEntryDTO>> GetVaccinationHistoryByPatientIdAsync(int patientId)
        {
            var entries = await _vaccinationEntryRepository.GetByPatientIdAsync(patientId);
            var entriesDTO = _mapper.Map<IEnumerable<VaccinationEntryDTO>>(entries); // Mapping from entity to DTO
            return entriesDTO;
        }

        // Get Vaccination entry by ID
        public async Task<VaccinationEntryDTO> GetVaccinationEntryByIdAsync(int id)
        {
            var entry = await _vaccinationEntryRepository.GetByIdAsync(id);
            if (entry == null)
                throw new KeyNotFoundException("Vaccination entry not found");

            var entryDTO = _mapper.Map<VaccinationEntryDTO>(entry); // Mapping from entity to DTO
            return entryDTO;
        }

        // Add a new Vaccination entry
        public async Task AddVaccinationEntryAsync(VaccinationEntryDTO vaccinationEntryDTO)
        {
            var vaccinationEntry = _mapper.Map<VaccinationEntry>(vaccinationEntryDTO); // Mapping from DTO to entity
            await _vaccinationEntryRepository.AddAsync(vaccinationEntry);
        }

        // Delete Vaccination entry by ID
        public async Task DeleteVaccinationEntryAsync(int id)
        {
            var entry = await _vaccinationEntryRepository.GetByIdAsync(id);
            if (entry == null)
                throw new KeyNotFoundException("Vaccination entry not found");

            await _vaccinationEntryRepository.DeleteAsync(entry.Id);
        }
    }
}

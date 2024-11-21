using AutoMapper;
using CovidVaccinationSystem.Core.Entities;
 using CovidVaccinationSystem.Services.Interfaces;
 using CovidVaccinationSystem.Core.DTOS;
using CovidVaccinationSystem.Core.Interfaces;

namespace CovidVaccinationSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public PatientService(IMapper mapper, IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        // Return a collection of PatientDTO
        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllAsync();
            var patientDTOs = _mapper.Map<IEnumerable<PatientDTO>>(patients);  // Map entities to DTOs
            return patientDTOs;
        }

        // Return a single PatientDTO
        public async Task<PatientDTO> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) throw new KeyNotFoundException("Patient not found");

            var patientDTO = _mapper.Map<PatientDTO>(patient);  // Map entity to DTO
            return patientDTO;
        }

        // Add a new Patient
        public async Task AddPatientAsync(PatientDTO patientDTO)
        {
            var patient = _mapper.Map<Patient>(patientDTO);  // Map DTO to entity
            await _patientRepository.AddAsync(patient);
        }

        // Update an existing Patient
        public async Task UpdatePatientAsync(PatientDTO patientDTO)
        {
            var existingPatient = await _patientRepository.GetByIdAsync(patientDTO.Id);
            if (existingPatient == null) throw new KeyNotFoundException("Patient not found");

            var patient = _mapper.Map<Patient>(patientDTO);  // Map DTO to entity
            await _patientRepository.UpdateAsync(patient);
        }

        // Delete a Patient
        public async Task DeletePatientAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) throw new KeyNotFoundException("Patient not found");

            await _patientRepository.DeleteAsync(patient.Id);
        }
    }
}

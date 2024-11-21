using CovidVaccinationSystem.Core.DTOS;
using CovidVaccinationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationSystem.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
        Task<PatientDTO> GetPatientByIdAsync(int id);
        Task AddPatientAsync(PatientDTO patientDTO);
        Task UpdatePatientAsync(PatientDTO patientDTO);
        Task DeletePatientAsync(int id);
    }
}

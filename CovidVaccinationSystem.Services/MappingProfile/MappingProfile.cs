using AutoMapper;
using CovidVaccinationSystem.Core.Entities;
using CovidVaccinationSystem.Core.DTOS;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, PatientDTO>();
        CreateMap<VaccinationEntry, VaccinationEntryDTO>();

        CreateMap<PatientDTO, Patient>();
        CreateMap<VaccinationEntryDTO, VaccinationEntry>();
    }
}

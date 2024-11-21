using CovidVaccinationSystem.Core.DTOS;
using FluentValidation;

namespace CovidVaccinationSystem.Services.Validation
{
    
    public class VaccinationEntryValidator : AbstractValidator<VaccinationEntryDTO>
    {
        public VaccinationEntryValidator()
        {
            RuleFor(ve => ve.PatientId).NotEmpty().WithMessage("Please Enter Patient ID")
                .GreaterThan(0).WithMessage("Patient ID must be greater than 0.");

            RuleFor(ve => ve.VaccineName)
                .NotEmpty().WithMessage("Vaccine name is required.")
                .MaximumLength(100).WithMessage("Vaccine name cannot exceed 100 characters.");

            RuleFor(ve => ve.VaccinationDate)
                .NotNull().WithMessage("Vaccination date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Vaccination date cannot be in the future.");

            
        }
    }

}

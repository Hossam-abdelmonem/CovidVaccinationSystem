using CovidVaccinationSystem.Core.DTOS;
using FluentValidation;
 

namespace CovidVaccinationSystem.Services.Validation
{
    public class PatientValidator : AbstractValidator<PatientDTO>
    {
        public PatientValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(p => p.IsVaccinated)
                .NotNull().WithMessage("Vaccination status is required.");
        }
    }

}

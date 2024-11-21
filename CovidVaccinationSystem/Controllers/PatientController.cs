  using CovidVaccinationSystem.Core.DTOS;
using CovidVaccinationSystem.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CovidVaccinationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IValidator<PatientDTO> _patientValidator;

        public PatientController(IValidator<PatientDTO> patientValidator,IPatientService patientService)
        {
            _patientService = patientService;
            _patientValidator = patientValidator;

        }

        // GET: api/patient
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);  // No need to map here, service returns DTOs
        }

        // GET: api/patient/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientByIdAsync(id);
                return Ok(patient);  // Returns DTO directly
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/patient
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientDTO patientDTO)
        {
            // Trigger validation
            var validationResult = await _patientValidator.ValidateAsync(patientDTO);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);  // Return validation errors
            }
            await _patientService.AddPatientAsync(patientDTO);
            return CreatedAtAction(nameof(GetById), new { id = patientDTO.Id }, patientDTO);
        }

        // PUT: api/patient/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientDTO patientDTO)
        {
            // Trigger validation
            var validationResult = await _patientValidator.ValidateAsync(patientDTO);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);  // Return validation errors
            }

            try
            {
                patientDTO.Id = id;  // Ensure the patient ID is correct
                await _patientService.UpdatePatientAsync(patientDTO);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/patient/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _patientService.DeletePatientAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

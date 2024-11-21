using CovidVaccinationSystem.Core.DTOS;
using CovidVaccinationSystem.Services.Interfaces;
using CovidVaccinationSystem.Services.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CovidVaccinationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccinationEntriesController : ControllerBase
    {
        private readonly IVaccinationEntryService _vaccinationEntryService;
        private readonly IValidator<VaccinationEntryDTO> _VaccinationEntryValidator;

        public VaccinationEntriesController(IValidator<VaccinationEntryDTO> VaccinationEntryValidator,  IVaccinationEntryService vaccinationEntryService)
        {
            _vaccinationEntryService = vaccinationEntryService;
            _VaccinationEntryValidator = VaccinationEntryValidator;
        }

        // GET: api/vaccinationentries/history/{patientId}
        [HttpGet("history/{patientId}")]
        public async Task<IActionResult> GetHistory(int patientId)
        {
            try
            {
                var history = await _vaccinationEntryService.GetVaccinationHistoryByPatientIdAsync(patientId);
                return Ok(history);  // Returns VaccinationEntryDTOs
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/vaccinationentries/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entry = await _vaccinationEntryService.GetVaccinationEntryByIdAsync(id);
                return Ok(entry);  // Returns VaccinationEntryDTO
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/vaccinationentries
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VaccinationEntryDTO vaccinationEntryDTO)
        {
            try
            {
                var validationResult = await _VaccinationEntryValidator.ValidateAsync(vaccinationEntryDTO);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);  // Return validation errors
                }
                await _vaccinationEntryService.AddVaccinationEntryAsync(vaccinationEntryDTO);
                return CreatedAtAction(nameof(GetById), new { id = vaccinationEntryDTO.Id }, vaccinationEntryDTO);  // Returns VaccinationEntryDTO
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/vaccinationentries/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vaccinationEntryService.DeleteVaccinationEntryAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

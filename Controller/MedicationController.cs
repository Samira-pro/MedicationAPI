using MedicationAPI.Models;
using MedicationAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicationAPI.Controller;


[Route("api/[controller]")]
[ApiController]
public class MedicationController : ControllerBase
{
    private readonly IMedicationService _medicationService;

    public MedicationController(IMedicationService medicationService)
    {
        _medicationService = medicationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Medication>>> GetMedications()
    {
        try
        {
            var medications = await _medicationService.GetMedicationsAsync();
            return Ok(medications);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error", details = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Medication>> CreateMedication([FromBody] Medication medication)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var createdMedication = await _medicationService.CreateMedicationAsync(medication);
            return CreatedAtAction(nameof(GetMedications), new { id = createdMedication.Id }, createdMedication);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error", details = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedication(int id)
    {
        try
        {
            var isDeleted = await _medicationService.DeleteMedicationAsync(id);

            if (!isDeleted)
                return NotFound(new { message = "Medication not found." });

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error", details = ex.Message });
        }
    }
}


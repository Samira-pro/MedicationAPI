using System.ComponentModel.DataAnnotations;

namespace MedicationAPI.Controller.DTO;

public class CreateMedicationDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
    public int Quantity { get; set; }
}

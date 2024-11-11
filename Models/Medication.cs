using System.ComponentModel.DataAnnotations;

namespace MedicationAPI.Models;

public class Medication
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Medication name is required.")]
    [StringLength(100, ErrorMessage = "Medication name can't exceed 100 characters.")]
    public string Name { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
    public int Quantity { get; set; }

    public DateTime CreatedDate { get; set; }
}

using FluentAssertions.Common;
using System.ComponentModel.DataAnnotations;

namespace MedicationAPI.Models;

public class Medication(string name, int quantity)
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Medication name is required.")]
    [StringLength(100, ErrorMessage = "Medication name can't exceed 100 characters.")]
    public string Name { get; set; } = name;

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
    public int Quantity { get; set; } = quantity;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}

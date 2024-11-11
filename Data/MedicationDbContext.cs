using MedicationAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace MedicationAPI.Data;

public class MedicationDbContext : DbContext
{
    public MedicationDbContext(DbContextOptions<MedicationDbContext> options) : base(options)
    {
    }

    public DbSet<Medication> Medications { get; set; } // Medications table
}

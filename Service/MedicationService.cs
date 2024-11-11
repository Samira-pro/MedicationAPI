using MedicationAPI.Data;
using MedicationAPI.Models;

namespace MedicationAPI.Service;

public class MedicationService : IMedicationService
{
    private readonly MedicationDbContext _context;

    public MedicationService(MedicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medication>> GetMedicationsAsync()
    {
        return  _context.Medications.ToList();
    }

    public async Task<Medication> CreateMedicationAsync(Medication medication)
    {
        if (medication.Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        medication.CreatedDate = DateTime.UtcNow;

        _context.Medications.Add(medication);
        await _context.SaveChangesAsync();

        return medication;
    }

    public async Task<bool> DeleteMedicationAsync(int id)
    {
        var medication = await _context.Medications.FindAsync(id);
        if (medication == null)
            return false;

        _context.Medications.Remove(medication);
        await _context.SaveChangesAsync();

        return true;
    }
}


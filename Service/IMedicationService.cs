using MedicationAPI.Models;

namespace MedicationAPI.Service;

public interface IMedicationService
{
    Task<IEnumerable<Medication>> GetMedicationsAsync();
    Task<Medication> CreateMedicationAsync(Medication medication);
    Task<bool> DeleteMedicationAsync(int id);
}


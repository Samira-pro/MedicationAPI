namespace MedicationAPI.Controller.DTO;

public class MedicationDto : EntityDto<int>
{
    public string Name { get; set; }

    public int Quantity { get; set; }

    public DateTime CreationDate { get; set; }
}

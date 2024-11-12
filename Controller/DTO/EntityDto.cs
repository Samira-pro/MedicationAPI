namespace MedicationAPI.Controller.DTO;


public class EntityDto : EntityDto<int>
{
    public EntityDto()
    {
    }
    public EntityDto(int id)
        : base(id)
    {
    }
}
public class EntityDto<TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }

    public EntityDto()
    {
    }

    public EntityDto(TPrimaryKey id)
    {
        Id = id;
    }
}

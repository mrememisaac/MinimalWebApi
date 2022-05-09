namespace MinimalWebApi.Entities;

public class Entity
{
    public Guid Id { get; }

    public Entity(Guid id)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
    }
}

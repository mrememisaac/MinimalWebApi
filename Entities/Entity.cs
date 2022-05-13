namespace MinimalWebApi.Entities;

public abstract class Entity
{
    /// <summary>
    /// Unique Identifier for every Entity in our application domain
    /// </summary>
    /// <value></value>
    public Guid Id { get; protected set; }

    public string CreatedBy { get; set; } = string.Empty;

    public DateTimeOffset DateCreated { get; set; }
}

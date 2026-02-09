namespace VirtualPlanetarium.CodeFirst.Models;

public class ObjectType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<CelestialObject> CelestialObjects { get; set; } = new List<CelestialObject>();
}
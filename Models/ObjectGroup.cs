namespace VirtualPlanetarium.CodeFirst.Models;

public class ObjectGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? GroupCode { get; set; } // Нове поле

    public ICollection<CelestialObject> CelestialObjects { get; set; } = new List<CelestialObject>();
}
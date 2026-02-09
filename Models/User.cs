namespace VirtualPlanetarium.CodeFirst.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public int ObsCount { get; set; }

    // Завдання 6 (частина 2): Owned Entity
    public Address? Address { get; set; }

    public ICollection<Observation> Observations { get; set; } = new List<Observation>();
}
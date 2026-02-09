namespace VirtualPlanetarium.CodeFirst.Models;

public class Observation
{
    public int Id { get; set; }
    public DateTime ObservationDate { get; set; }
    public string? Notes { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int CelestialObjectId { get; set; }
    public CelestialObject CelestialObject { get; set; } = null!;
}
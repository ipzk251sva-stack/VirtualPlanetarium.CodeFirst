namespace VirtualPlanetarium.CodeFirst.Models;

public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; } // 1-5
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }

    // Зв'язки
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int CelestialObjectId { get; set; }
    public CelestialObject CelestialObject { get; set; } = null!;
}
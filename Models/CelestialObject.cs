using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPlanetarium.CodeFirst.Models;

public class CelestialObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Назва об'єкта є обов'язковою")]
    [Display(Name = "Назва об'єкта")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Опис")]
    public string? Description { get; set; }

    [Display(Name = "Відстань (а.о.)")]
    public decimal? RightAscension { get; set; }

    [Display(Name = "Швидкість")]
    public decimal? Declination { get; set; }

    [Display(Name = "Дата відкриття")]
    [DataType(DataType.Date)]
    public DateTime? DateDiscovered { get; set; }

    [Display(Name = "Спектральний клас")]
    public string? SpectralClass { get; set; }

    // 🔥 ВИПРАВЛЕННЯ: Теги тепер просто рядок, а не складний список
    [Display(Name = "Теги")]
    public string? Tags { get; set; }

    // Зовнішні ключі
    [Required(ErrorMessage = "Тип об'єкта є обов'язковим")]
    [Range(1, int.MaxValue, ErrorMessage = "Оберіть тип об'єкта")]
    public int TypeId { get; set; }
    public int? GroupId { get; set; }

    // Навігаційні властивості (зв'язки)
    public ObjectType Type { get; set; } = null!;
    public ObjectGroup? Group { get; set; }

    public ICollection<Observation> Observations { get; set; } = new List<Observation>();

    // ❌ КОЛІР ВИДАЛЕНО (Color) - він більше не потрібен у базі
}
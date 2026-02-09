namespace VirtualPlanetarium.CodeFirst.Models
{
    // Це Owned Entity - у нього немає власного Id
    public class Address
    {
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
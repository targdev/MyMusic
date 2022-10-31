namespace MyMusic.Application.Models
{
    public class AcquiredMusics
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public AcquiredArtists Artist { get; init; }
    }
}

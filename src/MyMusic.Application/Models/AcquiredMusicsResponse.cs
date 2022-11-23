namespace MyMusic.Application.Models
{
    public class AcquiredMusicsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public AcquiredArtistsResponse Artist { get; init; }
    }
}

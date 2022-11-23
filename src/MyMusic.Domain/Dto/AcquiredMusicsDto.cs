namespace MyMusic.Domain.Dto
{
    public class AcquiredMusicsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public AcquiredArtistsDto Artist { get; set; }
    }
}

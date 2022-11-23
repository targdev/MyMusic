using MyMusic.Domain.Dto;

namespace MyMusic.Domain.Abstractions.Gateways
{
    public interface IMusicGateway
    {
        List<AcquiredMusicsDto> GetAllMusics();

        List<AcquiredMusicsDto> GetMusicsByName(string name);
    }
}

using System;
using System.Collections.Generic;

namespace MyMusic.Domain.Entities
{
    public class MusicEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }   
        public ArtistEntity Artist { get; set; }
        public List<PlaylistMusicEntity> PlaylistMusic { get; set; }
    }
}

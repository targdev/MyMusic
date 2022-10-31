using System;
using System.Collections.Generic;

namespace MyMusic.Domain.Entities
{
    public class ArtistEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<MusicEntity> Musics { get; set; }
    }
}
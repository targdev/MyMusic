using System;
using System.Collections.Generic;

namespace MyMusic.Domain.Entities
{
    public class PlaylistEntity
    {
        public Guid Id { get; set; }
        public List<PlaylistMusicEntity> PlaylistMusic { get; set; } 
    }
}
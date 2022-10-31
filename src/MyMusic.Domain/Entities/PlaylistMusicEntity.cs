using System;
using System.Collections;
using System.Collections.Generic;

namespace MyMusic.Domain.Entities
{
    public class PlaylistMusicEntity
    {
        public Guid PlaylistId { get; set; }
        public PlaylistEntity Playlist { get; set; }
        public Guid MusicId { get; set; }
        public MusicEntity Music { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MyMusic.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid playlistid { get; set; }
        public PlaylistEntity Playlist { get; set; }
    }
}

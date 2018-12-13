using Belatrix.Models;

namespace Belatrix.Repository
{
    public interface IPlaylistTrackRepository:IRepository<PlaylistTrack>
    {
        PlaylistTrack GetById(int id);
    }
}

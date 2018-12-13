using Belatrix.Models;

namespace Belatrix.Repository
{
    public interface IPlaylistRepository:IRepository<Playlist>
    {
        Playlist GetById(int id);
    }
}

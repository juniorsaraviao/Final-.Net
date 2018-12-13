using Belatrix.Models;

namespace Belatrix.Repository
{
    public interface IAlbumRepository:IRepository<Album>
    {
        Album GetById(int id);
    }
}

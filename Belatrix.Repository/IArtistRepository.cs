using Belatrix.Models;

namespace Belatrix.Repository
{
    public interface IArtistRepository:IRepository<Artist>
    {
        Artist GetById(int id);
    }
}

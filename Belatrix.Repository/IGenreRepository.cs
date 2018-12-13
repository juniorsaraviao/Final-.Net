using Belatrix.Models;

namespace Belatrix.Repository
{
    public interface IGenreRepository:IRepository<Genre>
    {
        Genre GetById(int id);
    }
}

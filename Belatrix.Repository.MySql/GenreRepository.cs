using Belatrix.Models;
using System.Linq;

namespace Belatrix.Repository.MySql
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ChinookContext dbContext) : base(dbContext)
        {
        }

        public Genre GetById(int id)
        {
            return _dbContext.Genre.FirstOrDefault(x => x.GenreId == id);
        }
    }
}

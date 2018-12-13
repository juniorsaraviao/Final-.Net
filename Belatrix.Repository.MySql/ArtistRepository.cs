using Belatrix.Models;
using System.Linq;

namespace Belatrix.Repository.MySql
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ChinookContext dbContext) : base(dbContext)
        {
        }

        public Artist GetById(int id)
        {
            return _dbContext.Artist.FirstOrDefault(x => x.ArtistId == id);
        }
    }
}

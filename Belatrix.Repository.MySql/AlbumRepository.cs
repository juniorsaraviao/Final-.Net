using Belatrix.Models;
using System.Linq;

namespace Belatrix.Repository.MySql
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(ChinookContext dbContext) : base(dbContext)
        {
        }

        public Album GetById(int id)
        {
            return _dbContext.Album.FirstOrDefault(x => x.AlbumId == id);
        }
    }
}
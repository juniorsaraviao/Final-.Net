using Belatrix.Models;
using System.Linq;

namespace Belatrix.Repository.SqlServer
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(ChinookContext dbContext) : base(dbContext)
        {
        }

        public Playlist GetById(int id)
        {
            return _dbContext.Playlist.FirstOrDefault(x => x.PlaylistId == id);
        }
    }
}

using Belatrix.Models;
using System.Linq;

namespace Belatrix.Repository.MySql
{
    public class PlaylistTrackRepository : Repository<PlaylistTrack>, IPlaylistTrackRepository
    {
        public PlaylistTrackRepository(ChinookContext dbContext) : base(dbContext)
        {
        }

        public PlaylistTrack GetById(int id)
        {
            return _dbContext.PlaylistTrack.FirstOrDefault(x => x.PlaylistId == id);
        }
    }
}

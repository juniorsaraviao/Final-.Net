using Belatrix.Models;

namespace Belatrix.Repository.SqlServer
{
    public class UnitofWork : IUnitofWork
    {
        public UnitofWork(ChinookContext dbContext)
        {
            Genres = new GenreRepository(dbContext);
            Playlists = new PlaylistRepository(dbContext);
        }
        public IGenreRepository Genres { get; }
        public IPlaylistRepository Playlists { get; }
    }
}

using Belatrix.Models;

namespace Belatrix.Repository.MySql
{
    public class UnitofWork : IUnitofWork
    {
        public UnitofWork(ChinookContext dbContext)
        {
            Genres = new GenreRepository(dbContext);
            Playlists = new PlaylistRepository(dbContext);
            Artists = new ArtistRepository(dbContext);
            Medias = new MediaTypeRepository(dbContext);
            Albums = new AlbumRepository(dbContext);
            PlaylistTracks = new PlaylistTrackRepository(dbContext);
        }
        public IGenreRepository Genres { get; }
        public IPlaylistRepository Playlists { get; }
        public IArtistRepository Artists { get; }
        public IMediaTypeRepository Medias { get; }
        public IAlbumRepository Albums { get; }
        public IPlaylistTrackRepository PlaylistTracks { get; }
    }
}

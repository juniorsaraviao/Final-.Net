namespace Belatrix.Repository
{
    public interface IUnitofWork
    {
        IGenreRepository Genres { get; }
        IPlaylistRepository Playlists { get; }
        IArtistRepository Artists { get; }
        IMediaTypeRepository Medias { get; }
        IAlbumRepository Albums { get; }
        IPlaylistTrackRepository PlaylistTracks { get; }
    }
}

using Belatrix.Models;

namespace Belatrix.Repository
{
    public interface IMediaTypeRepository:IRepository<MediaType>
    {
        MediaType GetById(int id);
    }
}

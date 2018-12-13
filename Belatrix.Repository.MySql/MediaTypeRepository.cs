using Belatrix.Models;
using System.Linq;

namespace Belatrix.Repository.MySql
{
    public class MediaTypeRepository : Repository<MediaType>, IMediaTypeRepository
    {
        public MediaTypeRepository(ChinookContext dbContext) : base(dbContext)
        {
        }

        public MediaType GetById(int id)
        {
            return _dbContext.MediaType.FirstOrDefault(x => x.MediaTypeId == id);
        }
    }
}
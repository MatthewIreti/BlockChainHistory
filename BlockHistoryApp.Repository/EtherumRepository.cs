using BlockHistoryApp.Repository.Database;
using LiteDB;

namespace BlockHistoryApp.Repository
{
    public interface IEtherumRepository : IBaseRepository<BlockEntity>
    {

    }
    public class EtherumRepository : BaseRepository<BlockEntity>, IEtherumRepository
    {
        public EtherumRepository(ILiteDbContext db) : base(db)
        {
        }
    }
}

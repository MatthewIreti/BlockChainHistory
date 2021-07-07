using BlockHistoryApp.Repository.Database;
using LiteDB;

namespace BlockHistoryApp.Repository
{
    public interface IEtherumRepository : IBaseRepository<BlockEntity>
    {
        int DeleteAll();
    }
    public class EtherumRepository : BaseRepository<BlockEntity>, IEtherumRepository
    {
        public EtherumRepository(ILiteDbContext db) : base(db)
        {
        }

        public int DeleteAll()
        {
           return _db.GetCollection<BlockEntity>().DeleteAll();
        }
    }
}

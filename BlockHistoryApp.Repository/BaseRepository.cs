using BlockHistoryApp.Repository.Database;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHistoryApp.Repository
{
    public interface IBaseRepository<T>
    {
        T Create(T data);
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Update(T entity);
        bool Delete(int id);
    }
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public ILiteDatabase _db;
        public ILiteCollection<T> Collection { get; }
        public BaseRepository(ILiteDbContext db)
        {
            _db = db.Database;
            Collection = _db.GetCollection<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return Collection.FindAll();     
        }

        public T Create(T data)
        {
            var currentId = Collection.Insert(data);
            return FindById(currentId);
        }

        public bool Delete(int id)
        {
            return Collection.Delete(id);
        }

        public T FindById(int id)
        {
            return Collection.FindById(id);
        }

        public void Update(T entity)
        {
            Collection.Upsert(entity);
        }
    }
}

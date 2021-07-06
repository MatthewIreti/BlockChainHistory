using LiteDB;
using Microsoft.Extensions.Options;
using System;

namespace BlockHistoryApp.Repository.Database
{

    public interface ILiteDbContext
    {
        public LiteDatabase Database { get; }
    }
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            try
            {
                Database = new LiteDatabase(options.Value.DatabaseLocation);
            }
            catch (Exception ex)
            {

                throw new Exception("Cannot find database", ex);
            }
        }
    }

    public class LiteDbOptions
    {
        public string DatabaseLocation  { get; set; }
    }
}

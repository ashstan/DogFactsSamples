using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogFactsSamples.Models;
using DogFactsSamples;
using SQLite;

namespace DogFactsSamples.Data
{
    public class DogFactsDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DogFactsDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Fact).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Fact)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<Fact>> GetItemsAsync()
        {
            return Database.Table<Fact>().ToListAsync();
        }

        public Task<Fact> GetItemAsync(int id)
        {
            return Database.Table<Fact>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Fact item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> InsertList(IEnumerable<Fact> items)
        {
            return Database.InsertAllAsync(items);
        }

        public Task<int> DeleteItemAsync(Fact item)
        {
            return Database.DeleteAsync(item);
        }
        public Task<int> ClearAllAsync()
        {
            return Database.DeleteAllAsync<Fact>();
        }
    }
}

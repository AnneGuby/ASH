using System.Data;
using System.Data.Entity;

namespace EmployeesAPI.Repositories
{
    public class BaseRepository
    {
        protected T GetContext<T>(string database) where T : DbContext, new()
        {
            var db = new T();
            db.Database.Connection.ConnectionString = GetConnectionString(database.ToString());

            return db;
        }

        protected async Task<TResult> ExecuteSnapshotQueryAsync<TResult, TContext>(Func<TContext, Task<TResult>> query, bool debug = false) where TContext : DbContext, new()
        {
            return await ExecuteIsolationLevelQueryAsync(query, IsolationLevel.Snapshot, "Main", debug);
        }

        private async Task<TResult> ExecuteIsolationLevelQueryAsync<TResult, TContext>(Func<TContext, Task<TResult>> query, IsolationLevel isolationLevel, string database, bool debug) where TContext : DbContext, new()
        {
            TResult result;
            using (var ctx = database == null ? new TContext() : GetContext<TContext>(database))
            {
                using (var trans = ctx.Database.BeginTransaction(isolationLevel))
                {
                    if (debug)
                        ctx.Database.Log = s => System.Diagnostics.Debug.Write(s);
                    result = await query(ctx);
                    trans.Commit();
                }
            }
            return result;
        }
        public string GetConnectionString(string key)
        {
            var connectionString = $"~";
            return connectionString;
        }
    }
}

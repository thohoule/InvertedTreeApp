using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccess.DBAccess
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private const string Default_Connection = "Default";
        private string connectionString;
        //private readonly IConfiguration config;

        public SQLDataAccess(IConfiguration config, string connectionID = Default_Connection) :
            this(config.GetConnectionString(connectionID))
        { }

        public SQLDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<TItem> LoadData<TItem, TParameter>(string storedProcedure,
            TParameter parameters, string connectionID = Default_Connection)
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            return connection.Query<TItem>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TItem>> LoadDataAsync<TItem, TParameter>(string storedProcedure,
            TParameter parameters, string connectionID = Default_Connection)
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<TItem>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void SaveData<TItem>(string storedProcedure,
            TItem parameters, string connectionID = Default_Connection)
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            connection.Execute(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveDataAsync<TItem>(string storedProcedure,
            TItem parameters, string connectionID = Default_Connection)
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}

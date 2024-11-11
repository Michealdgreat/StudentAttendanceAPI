using Common.Domain.Repository;
using Dapper;
using Npgsql;
using System.Data;


namespace StuAttendanceAPI.Infrastructure.Repositories.Base
{
    /// <summary>
    /// BASE REPOSITORY
    /// All repositories inherits from this base class.
    /// </summary>
    /// <param name="configuration"></param>
    public class BaseRepository() : IBaseRepository

    {


        public async Task<int> SaveData<T>(string dBSp, T parameters)
        {

            using IDbConnection connection = new NpgsqlConnection(BaseConstants.StuAttConnectionString);

            return await connection.ExecuteAsync(dBSp, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<int> DeleteData<T>(string dBSp, T parameters)
        {

            using IDbConnection connection = new NpgsqlConnection(BaseConstants.StuAttConnectionString);

            var result = await connection.ExecuteAsync(dBSp, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }


        public async Task<T?> LoadOneData<T, U>(string sqlQuery, U parameters)
        {


            using IDbConnection connection = new NpgsqlConnection(BaseConstants.StuAttConnectionString);
            var result = await connection.QueryFirstOrDefaultAsync<T>(sqlQuery, parameters);

            return result;

        }

        public async Task<List<T>> LoadData<T, U>(string dpSp, U parameters)
        {

            using IDbConnection connection = new NpgsqlConnection(BaseConstants.StuAttConnectionString);

            var results = await connection.QueryAsync<T>(dpSp, parameters);

            return results.AsList();
        }

    }
}
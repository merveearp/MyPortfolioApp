using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace MyPortfolioApp.Data;

public class DapperRepository<T> : IRepository<T> where T : class
{
    private readonly string _connectionStrings;
    private readonly string _tableName;
    public DapperRepository()
    {
        _connectionStrings="Server=localhost,1440;Database=MyPortfolioDb;User=SA;Password=YourStrong@Passw0rd;TrustServerCertificate=true";
        _tableName=typeof(T).Name;
        if(_tableName.EndsWith("y")){
            _tableName=_tableName.Substring(0,_tableName.Length-1)+"ies";
        }
        else{
            _tableName+="s";
        }
    }
    private IDbConnection CreateConnection(){
        return new SqlConnection(_connectionStrings);
    }
    public async Task<int> AddAsync(T entity)
    {
       using (var connection = CreateConnection())
        {
            var query=$"INSERT INTO {_tableName}(/*columns*/) VALUES (/*values*/)";
            return await connection.ExecuteAsync(query,entity);
        }
        
    }

    public async Task<int> DeleteAsync(int id)
    {
        using (var connection = CreateConnection())
        {
            var query=$"DELETE FROM {_tableName} WHERE Id ={id}";
            return await connection.ExecuteAsync(query , new { Id=id});
        }
        
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
         using (var connection = CreateConnection())
        {
            var query=$"SELECT*FROM {_tableName}";
            return await connection.QueryAsync<T>(query);
        }
    }

    public async Task<T?> GetAsync(int id)
    {
        using (var connection = CreateConnection())
        {
            var query=$"SELECT*FROM {_tableName} WHERE Id =@Id";
            var result = await connection.QueryFirstOrDefaultAsync<T>(query, new {Id=id});
            return result ?? null;
        }
    }

    public async Task<int> UpdateAsync(T entity)
    {
        using (var connection =CreateConnection())
        {
          var query =$"UPDATE {_tableName} SET /*column=@Value*/ WHERE Id =@Id";  
          return await connection.ExecuteAsync(query,entity);
        }
        
    }
}

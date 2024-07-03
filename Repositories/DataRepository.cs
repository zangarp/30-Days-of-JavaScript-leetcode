using Dapper;
using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;
using FinOpsAPI.Models.Employee;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinOpsAPI.Repositories;

public class DataRepository : IDataRepository
{
    private readonly IDbConnection _connection;
    public DataRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public async Task<IEnumerable<DepDirectory>> GetDepDirectory()
    {
        string q = @"select * from Planning.dbo.DepDirectory";
        return await _connection.QueryAsync<DepDirectory>(q);
    }
    public async Task<IEnumerable<Data>> GetData()
    {
        string query = @"SELECT * FROM Planning.dbo.[Data]";
        return await _connection.QueryAsync<Data>(query);
    }
}

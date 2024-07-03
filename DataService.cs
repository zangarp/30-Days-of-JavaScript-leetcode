using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;
using FinOpsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinOpsAPI.Services;

public class DataService
{
    private readonly IDataRepository _dataRepository;

    public DataService (
           IDataRepository dataRepository
    )
    {
        _dataRepository = dataRepository;
    }
    public async Task<IEnumerable<DepDirectory>> GetDepDirectory()
    {
        return await _dataRepository.GetDepDirectory();
    }
    public async Task<IEnumerable<Data>> GetData()
    {
        return await _dataRepository.GetData();
    }
    public async Task<ActionResult> AddData(Data data)
    {
        return await _dataRepository.AddData(data);
    }
}

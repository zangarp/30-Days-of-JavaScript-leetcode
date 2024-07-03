using FinOpsAPI.Models;
using FinOpsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinOpsAPI.Controllers;

public class DataController : Controller
{
    private readonly DataService _dataService;
    public DataController(DataService dataService)
    {
        _dataService = dataService;
    }
    [HttpGet("getDepDirectory")]
    public async Task<IEnumerable<DepDirectory>> GetDepDirectory()
    {
        return await _dataService.GetDepDirectory();
    }

    [HttpGet("getData")]
    public async Task<IEnumerable<Data>> GetData()
    {
        return await _dataService.GetData();
    }

    [HttpPost("addData")]
    public async Task<ActionResult> AddData([FromBody] Data data)
    {
        return await _dataService.AddData(data);
    }
}

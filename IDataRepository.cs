using FinOpsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinOpsAPI.Interfaces;

public interface IDataRepository
{
    Task<IEnumerable<DepDirectory>> GetDepDirectory();
    Task<IEnumerable<Data>> GetData();
    Task<ActionResult> AddData(Data data);
}

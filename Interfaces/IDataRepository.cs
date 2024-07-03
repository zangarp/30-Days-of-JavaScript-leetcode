using FinOpsAPI.Models;

namespace FinOpsAPI.Interfaces;

public interface IDataRepository
{
    Task<IEnumerable<DepDirectory>> GetDepDirectory();
    Task<IEnumerable<Data>> GetData();
}

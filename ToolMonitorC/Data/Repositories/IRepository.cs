using ToolMonitorC.Data.Entities;

namespace ToolMonitorC.Data.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
    }
}

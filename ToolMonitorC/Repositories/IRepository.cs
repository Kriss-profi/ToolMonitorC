using ToolMonitorC.Entities;

namespace ToolMonitorC.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
    }
}

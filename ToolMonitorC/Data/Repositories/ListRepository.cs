using ToolMonitorC.Data.Entities;

namespace ToolMonitorC.Data.Repositories;

public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    protected readonly List<T> _items = new();

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }
    public T GetById(int id)
    {
        return _items.Single(item => item.Id == id);
    }

    public void Add(T items)
    {
        items.Id = _items.Count +1;
        _items.Add(items);
    }
    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public void Save()
    {
        // Narazie nie ma 
    }

}

using System;

namespace Practice.Core.Repository;

public class MemoryRepository<T> : IRepository<T> where T : IIdentifiable
{

    private List<T> _collection { get; set; } = new List<T>();
    public void Add(T element)
    {
        _collection.Add(element);
    }

    public T? FindById(int id)
    {
        return _collection.FirstOrDefault(el => el.Id == id);
    }

    public List<T> GetAll()
    {
        return _collection.ToList();
    }
}

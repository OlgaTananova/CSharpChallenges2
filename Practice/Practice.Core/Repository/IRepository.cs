using System;

namespace Practice.Core.Repository;

public interface IRepository<T>
{
    void Add(T element);
    List<T> GetAll();
    T? FindById(int id);
}

public interface IIdentifiable
{
    int Id { get; set; }
}

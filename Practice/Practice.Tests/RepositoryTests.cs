using System;
using Practice.Core.Repository;

namespace Practice.Tests;

public class Order : IIdentifiable
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;


}
public class RepositoryTests
{

    [Fact]
    public void Add_ShouldAddItemToRepository()
    {
        // Arrange 
        MemoryRepository<Order> _repository = new MemoryRepository<Order> { };
        Order newOrder = new Order { Id = 1, CustomerName = "John" };

        //Act
        _repository.Add(newOrder);


        Assert.NotEmpty(_repository.GetAll());

    }

    [Fact]
    public void FindById_ShouldReturnCorrectItem()
    {
        // Arrange 
        MemoryRepository<Order> _repository = new MemoryRepository<Order> { };
        Order newOrder = new Order { Id = 2, CustomerName = "Alice" };
        _repository.Add(newOrder);

        //Act
        var result = _repository.FindById(2);

        Assert.NotNull(result);
        Assert.Equal(newOrder.CustomerName, result.CustomerName);

    }

    [Fact]
    public void FindById_ShouldReturnNull_WhenInvalidId()
    {
        // Arrange 
        MemoryRepository<Order> _repository = new MemoryRepository<Order> { };
        Order newOrder = new Order { Id = 2, CustomerName = "Alice" };
        _repository.Add(newOrder);

        //Act
        var result = _repository.FindById(999);

        Assert.Null(result);

    }

    [Fact]
    public void GetAll_ShouldReturnCorrectCount()
    {
        // Arrange 
        MemoryRepository<Order> _repository = new MemoryRepository<Order> { };
        Order newOrder1 = new Order { Id = 1, CustomerName = "John" };
        Order newOrder2 = new Order { Id = 2, CustomerName = "Alice" };

        _repository.Add(newOrder2);
        _repository.Add(newOrder1);

        //Act
        var result = _repository.GetAll();

        Assert.NotEmpty(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(newOrder1, result);
        Assert.Contains(newOrder2, result);

    }
}
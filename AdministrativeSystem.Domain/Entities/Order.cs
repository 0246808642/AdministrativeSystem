using AdministrativeSystem.Domain.Enum;

namespace AdministrativeSystem.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public Guid ClientId { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    private readonly List<OrderItem> _orderItems;
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    
    protected  Order() // EF
    {}

    public Order(Guid clientId)
    {
        Id = Guid.NewGuid();
        ClientId = clientId;
        Status = OrderStatus.Draft;
        CreatedAt = DateTime.UtcNow;
        _orderItems = new List<OrderItem>();
    }

    public void AddItem(Product product, int quantity)
    {
        if(Status == OrderStatus.Closed)
            throw new InvalidOperationException("Cannot add an item to a order that is closed.");
        if(!product.IsActive)
            throw new InvalidOperationException("Cannot add an item to a order that is not active.");
        
        var item = new OrderItem(product.Id, quantity, product.Price);
        _orderItems.Add(item);
    }

    public void Close()
    {
        if(_orderItems.Any())
            throw new InvalidOperationException("Cannot close an order that is closed.");
        Status = OrderStatus.Closed;
    }

    public decimal GetTotal()
    {
        return _orderItems.Sum(i => i.CalculateTotalPrice());
    }
    
}
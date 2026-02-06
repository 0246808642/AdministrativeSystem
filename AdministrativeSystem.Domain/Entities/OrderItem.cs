namespace AdministrativeSystem.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    protected OrderItem() {}

    internal OrderItem(Guid productId, int quantity, decimal unitPrice)
    {
        if(quantity <= 0)
            throw new ArgumentException("Quantity must be greater than or equal to 0.");
        
        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public decimal CalculateTotalPrice()
    {
        return UnitPrice * Quantity;
    }
}
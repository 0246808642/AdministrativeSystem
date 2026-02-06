namespace AdministrativeSystem.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; }
    
    protected Product() {}

    public Product(string name, decimal price)
    {
        if (price <0)
            throw new ArgumentException("Price must be greater than or equal to 0.");
        
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        IsActive = true;
    }
    
    public void Deactivate()
    {
        IsActive = false;
    }

    public void ChangePrice(decimal newPrice)
    {
        if(newPrice <= 0)
            throw new ArgumentException("Price must be greater than or equal to 0.");
        
        Price = newPrice;
    }
}
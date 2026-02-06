namespace AdministrativeSystem.Application.UseCases.Orders.AddItemToOrder;

public class AddItemToOrderResponse
{
    public Guid OrderId { get; set; }
    public decimal Total { get; set; }

    public AddItemToOrderResponse(Guid orderId, decimal total)
    {
        OrderId = orderId;
        Total = total;
    }
}
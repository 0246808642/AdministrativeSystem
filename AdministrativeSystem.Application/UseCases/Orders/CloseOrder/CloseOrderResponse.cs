namespace AdministrativeSystem.Application.UseCases.Orders.CloseOrder;

public class CloseOrderResponse
{
    public Guid OrderId { get; set; }
    public decimal Total { get; set; }
    
    public CloseOrderResponse(Guid orderId, decimal total)
    {
        OrderId = orderId;
        Total = total;
    }
}
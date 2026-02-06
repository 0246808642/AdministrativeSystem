namespace AdministrativeSystem.Application.UseCases.Orders.CreateOrder;

public class CreateOrderResponse
{
    public Guid OrderId { get; set; }

    public CreateOrderResponse(Guid orderId)
    {
        OrderId = orderId;
    }
}
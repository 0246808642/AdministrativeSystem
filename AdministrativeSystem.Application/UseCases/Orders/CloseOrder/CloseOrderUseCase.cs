using AdministrativeSystem.Application.Interfaces.Repositories;

namespace AdministrativeSystem.Application.UseCases.Orders.CloseOrder;

public class CloseOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    public CloseOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<CloseOrderResponse> CloseOrder(CloseOrderRequest request)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        if(order is null)
            throw new InvalidOperationException("Order not found"); 
        
        order.Close();
        
        await _orderRepository.UpdateAsync(order);
        return new CloseOrderResponse(order.Id, order.GetTotal());
    }
}
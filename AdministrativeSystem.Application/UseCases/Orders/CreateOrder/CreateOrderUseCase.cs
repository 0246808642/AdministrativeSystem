using AdministrativeSystem.Application.Interfaces.Repositories;
using AdministrativeSystem.Domain.Entities;

namespace AdministrativeSystem.Application.UseCases.Orders.CreateOrder;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    
    public CreateOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<CreateOrderResponse> ExecuteAsync(CreateOrderRequest request)
    {
        var order = new Order(request.ClientId);
        
        await _orderRepository.AddAsync(order);
        return new CreateOrderResponse(order.Id);
    }
}
using AdministrativeSystem.Application.Interfaces.Repositories;

namespace AdministrativeSystem.Application.UseCases.Orders.AddItemToOrder;

public class AddItemToOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public AddItemToOrderUseCase(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<AddItemToOrderResponse> ExecuteAsync(AddItemToOrderRequest request)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        if (order == null)
        {
            throw new InvalidOperationException("Order not found");
        }

        var product = await _productRepository.GetByIdAsync(request.ProductId);
        if (product is null)
        {
            throw new InvalidOperationException("Product not found");
        }
        
        order.AddItem(product, request.Quantity);
        
        await _orderRepository.UpdateAsync(order);
        
        return new AddItemToOrderResponse(order.Id, order.GetTotal());
    }
}
using MediatR;
using OrderInChallenge.DataAccess.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace OrderInChallenge.Commands.Order.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IOrdersService _ordersService;

        public CreateOrderCommandHandler(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _ordersService.Create(request.OrderItems);
            CreateOrderResult createOrderResult = new CreateOrderResult(true);
            return Task.FromResult(createOrderResult);
        }
    }
}

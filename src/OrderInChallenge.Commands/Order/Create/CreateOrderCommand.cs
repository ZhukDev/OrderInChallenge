using MediatR;
using OrderInChallenge.DataAccess.Entities;
using System.Collections.Generic;

namespace OrderInChallenge.Commands.Order.Create
{
    public class CreateOrderCommand : IRequest<CreateOrderResult>
    {
        public List<OrderItem> OrderItems { get; set; }
    }
}

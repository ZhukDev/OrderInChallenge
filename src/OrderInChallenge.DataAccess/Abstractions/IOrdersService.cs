using OrderInChallenge.DataAccess.Entities;
using System.Collections.Generic;

namespace OrderInChallenge.DataAccess.Abstractions
{
    public interface IOrdersService
    {
        void Create(List<OrderItem> orderItems);
    }
}

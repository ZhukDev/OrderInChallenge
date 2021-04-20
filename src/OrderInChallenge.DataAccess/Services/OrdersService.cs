using OrderInChallenge.DataAccess.Abstractions;
using OrderInChallenge.DataAccess.Entities;
using System.Collections.Generic;

namespace OrderInChallenge.DataAccess.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _db;

        public OrdersService(AppDbContext db)
        {
            _db = db;
        }

        public void Create(List<OrderItem> orderItems)
        {
            Order order = new() { OrderItems = orderItems };
            _db.Orders.InsertOne(order);
        }
    }
}

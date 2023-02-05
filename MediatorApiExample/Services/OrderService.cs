using System.Collections.Generic;
using MediatorApiExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MediatorApiExample.Services
{
    public interface IOrderService
    {
        public List<Order> GetOrdersForCustomer(string customerId);

        public Order Get(ObjectId id);

        public Order Create(Order order);

        public void Update(ObjectId id, Order orderIn);

        public void Remove(Order orderIn);

        public void Remove(ObjectId id);
    }

    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(IMongoClient mongoClient, IOptions<MediatorApiDatabaseSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _orders = database.GetCollection<Order>(nameof(Order));
        }

        public List<Order> GetOrdersForCustomer(string customerId) =>
            _orders.Find(order => order.CustomerId == ObjectId.Parse(customerId)).ToList();

        public Order Get(ObjectId id) =>
            _orders.Find(order => order.Id == id).FirstOrDefault();

        public Order Create(Order order)
        {
            _orders.InsertOne(order);
            return order;
        }

        public void Update(ObjectId id, Order orderIn) =>
            _orders.ReplaceOne(order => order.Id == id, orderIn);

        public void Remove(Order orderIn) =>
            _orders.DeleteOne(order => order.Id == orderIn.Id);

        public void Remove(ObjectId id) =>
            _orders.DeleteOne(order => order.Id == id);
    }
}
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MediatorApiExample.Models
{
    public class Order
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonId]
        public ObjectId CustomerId { get; set; }

        public string ProductName { get; set; }

        public DateTimeOffset OrderPlaced { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public Order(string customerId, string productName, DateTimeOffset orderPlaced, int quantity, decimal amount)
        {
            this.CustomerId = ObjectId.Parse(customerId);
            this.ProductName = productName;
            this.OrderPlaced = orderPlaced;
            this.Quantity = quantity;
            this.Amount = amount;
        }
    }
}

using System;
using MediatR;

namespace MediatorApiExample.Dto
{
    public class OrderDto : IRequest
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public string ProductName { get; set; }

        public DateTimeOffset OrderPlaced { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public OrderDto(string productName, DateTimeOffset orderPlaced, int quantity, decimal amount)
        {
            this.ProductName = productName;
            this.OrderPlaced = orderPlaced;
            this.Quantity = quantity;
            this.Amount = amount;
        }
    }
}


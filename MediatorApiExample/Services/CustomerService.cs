using System.Collections.Generic;
using MediatorApiExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MediatorApiExample.Services
{
    public interface ICustomerService
    {
        public List<Customer> GetAll();

        public Customer Get(ObjectId id);

        public Customer Create(Customer customer);

        public void Update(ObjectId id, Customer customerIn);

        public void Remove(Customer customerIn);

        public void Remove(ObjectId id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IMongoClient mongoClient, IOptions<MediatorApiDatabaseSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _customer = database.GetCollection<Customer>(nameof(Customer));
        }

        public List<Customer> GetAll() => _customer.Find(customer => true).ToList();

        public Customer Get(ObjectId id) => _customer.Find(customer => customer.Id == id).FirstOrDefault();

        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public void Update(ObjectId id, Customer customerIn) =>
            _customer.ReplaceOne(customer => customer.Id == id, customerIn);

        public void Remove(Customer customerIn) =>
            _customer.DeleteOne(customer => customer.Id == customerIn.Id);

        public void Remove(ObjectId id) =>
            _customer.DeleteOne(customer => customer.Id == id);
    }
}

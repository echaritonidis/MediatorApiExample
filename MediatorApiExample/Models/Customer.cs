using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MediatorApiExample.Models
{
    public class Customer
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Customer(string firstName, string lastName, DateTime birthday)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }
    }

    public class CustomerApi
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime Birthday { get; private set; }
    }
}

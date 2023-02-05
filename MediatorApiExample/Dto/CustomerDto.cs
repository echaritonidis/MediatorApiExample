using System;
using MediatR;

namespace MediatorApiExample.Dto
{
    public class CustomerDto : IRequest
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public CustomerDto(string firstName, string lastName, DateTime birthday)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models.DTOs
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        public ClientDto(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Address = client.Address;
            City = client.City;
            PostalCode = client.PostalCode;
            Country = client.Country;
        }
    }
}

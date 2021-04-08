using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.DAO.Model
{
    public partial class Request
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string County { get; set; }
    }
}

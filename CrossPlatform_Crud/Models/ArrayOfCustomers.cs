using System.Collections.Generic;

namespace CrossPlatform_Crud.Models
{
    public class ArrayOfCustomers
    {
        public ArrayOfCustomers()
        {
            Customers = new List<Customer>();
        }
        public List<Customer> Customers { get; set; }
    }
}
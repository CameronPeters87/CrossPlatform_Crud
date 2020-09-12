using System.Data.Entity;

namespace CrossPlatform_Crud.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("CustomerDb")
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
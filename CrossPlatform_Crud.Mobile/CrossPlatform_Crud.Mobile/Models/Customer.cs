using System;

namespace CrossPlatform_Crud.Mobile.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Hire_Date { get; set; }
        public int Age { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace CrossPlatform_Crud.Models.ViewModels
{
    public class CreateCustomer
    {
        public int Id { get; set; }
        [Required, MinLength(2)]
        public string FirstName { get; set; }
        [Required, MinLength(2)]
        public string Surname { get; set; }
        [Required]
        public DateTime Hire_Date { get; set; }
        [Required]
        [Range(1, 70)]
        public int Age { get; set; }
    }
}
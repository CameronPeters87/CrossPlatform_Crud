using CrossPlatform_Crud.Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrossPlatform_Crud.Mobile.Logic
{
    public class CustomerLogic
    {
        // https://localhost:44379/api/Customers
        private string baseUrl = "https://api.covid19api.com/summary";
        public static async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(new Uri("https://localhost:44379/api/Customers"));
                var json = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<List<Customer>>(json);

                customers = model;
            }

            return customers;
        }
    }
}

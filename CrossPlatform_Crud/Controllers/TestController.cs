using CrossPlatform_Crud.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CrossPlatform_Crud.Controllers
{
    public class TestController : Controller
    {
        private string baseUrl = "https://localhost:44379/api/";
        // GET: Test
        public async Task<ActionResult> Index()
        {
            List<Customer> customers = new List<Customer>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage responseMessage = await client.GetAsync("Customers");

                if (responseMessage.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = responseMessage.Content
                        .ReadAsStringAsync().Result;

                    customers = JsonConvert.DeserializeObject<List<Customer>>(response);
                }
            }

            return View(customers);
        }

        public async Task<ActionResult> PostCustomer()
        {
            Customer customer = new Customer
            {
                FirstName = "Jane",
                Surname = "Doe",
                Hire_Date = DateTime.Today,
                Age = 40
            };

            var jsonCust = new JavaScriptSerializer().Serialize(customer);

            HttpContent t = new StringContent(jsonCust, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage responseMessage = await client.PostAsync("Customers", t);

                if (responseMessage.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    return RedirectToAction("index");
                }
            }


            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

    }
}
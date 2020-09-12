using CrossPlatform_Crud.Models;
using CrossPlatform_Crud.Models.ViewModels;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CrossPlatform_Crud.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();
        public async Task<ActionResult> Index()
        {
            return View(await db.Customers.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateCustomer model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CreateCustomerPartial", model);
            }

            db.Customers.Add(new Customer
            {
                FirstName = model.FirstName,
                Surname = model.Surname,
                Hire_Date = model.Hire_Date,
                Age = model.Age
            });

            await db.SaveChangesAsync();

            TempData["Customer_SM"] = "You successfully created a customer";

            return PartialView("_CreateCustomerPartial", model);
        }
    }
}
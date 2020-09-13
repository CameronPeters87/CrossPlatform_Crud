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

        public ActionResult Edit(int id)
        {
            var customer = db.Customers.Find(id);

            var model = new CreateCustomer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                Hire_Date = customer.Hire_Date,
                Age = customer.Age,
                Surname = customer.Surname
            };

            ViewBag.DateString = customer.Hire_Date.ToString("yyyy-MM-dd");

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CreateCustomer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = await db.Customers.FindAsync(model.Id);

            customer.FirstName = model.FirstName;
            customer.Surname = model.Surname;
            customer.Age = model.Age;
            customer.Hire_Date = model.Hire_Date;
            customer.Id = model.Id;

            db.Entry(customer).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return Redirect("/");
        }

        public async Task Delete(int id)
        {
            var customer = await db.Customers.FindAsync(id);

            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
        }
    }
}
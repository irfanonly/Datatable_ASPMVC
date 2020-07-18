using DataTableRemote.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DataTableRemote.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult records(DatatableParams<Customer> param)
        {

            var data = new DataRecord<Customer>();

            var customers = GetCustomers().AsQueryable();
            int totalCount;
            totalCount = customers.Count();

            customers = param.FilterOnAllSearchable(customers);


            data.draw = param.draw;
            data.recordsFiltered = customers.Count();
            data.recordsTotal = totalCount;
            data.data = customers;

            return Json(data, JsonRequestBehavior.AllowGet);
        }



        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Irfan",
                    salary = "100",
                    office = "OF",
                    position = "Posi",
                    start_date = "start"
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Rilwan",
                    salary = "100",
                    office = "OF",
                    position = "Posi",
                    start_date = "start"
                }
            };
        }
    }

}
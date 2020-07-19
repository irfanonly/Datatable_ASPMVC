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

            customers = param.OrderOnOrderable(customers);

            data.draw = param.draw;
            data.recordsFiltered = customers.Count();
            data.recordsTotal = totalCount;
            data.data = customers.Skip(param.start);

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
                    salary = 100,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1992,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Rilwan",
                    salary = 100,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1991,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Sallem",
                    salary = 100,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1993,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Hasseer",
                    salary = 100,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1986,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Rajni",
                    salary = 100,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1966,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Kamal",
                    salary = 100,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1978,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Irfan",
                    salary = 100,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1992,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Irfan",
                    salary = 100,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1992,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Irfan",
                    salary = 100,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1992,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Irfan",
                    salary = 200,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1992,2, 22)
                },
                new Customer
                {
                    first_name = "Mohammed",
                    last_name = "Irfan",
                    salary = 50,
                    office = "OF",
                    position = "Posi",
                    start_date = new System.DateTime(1992,2, 22)
                }


            };
        }
    }

}
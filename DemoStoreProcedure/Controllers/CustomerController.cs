using DemoStoreProcedure.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DemoStoreProcedure.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CustomerController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var GetAllCustomers = _db.Customer.FromSqlRaw("GetAllCustomers").ToList();
            return View(GetAllCustomers);
        }
        public IActionResult GetDetails(int? id)
        {
            var GetCustomerById = _db.Customer.FromSqlRaw($"GetCustomerById {id}").AsEnumerable().FirstOrDefault();
            return View(GetCustomerById);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDetails(int Id, string Mobile, string Name, string Email)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = Id
                },
                  new SqlParameter()
                {
                    ParameterName = "@Mobile",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Mobile
                },
                   new SqlParameter()
                {
                    ParameterName = "@Name",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Name
                },
                    new SqlParameter()
                {
                    ParameterName = "@Email",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = Email
                },
            };

            var UpdateCustomerById = await _db.Database.ExecuteSqlRawAsync($"Exec UpdateCustomer @Id,@Mobile,@Name,@Email", param);
            if (UpdateCustomerById == 1)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View();

            }

        }
    }
}

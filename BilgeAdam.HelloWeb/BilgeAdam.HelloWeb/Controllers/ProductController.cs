using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BilgeAdam.HelloWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.HelloWeb.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>();
            var str = "Server=.;Database=Northwind;User Id=student;Password=ba123";
            using (var conn = new SqlConnection(str))
            {
                conn.Open();

                var cmd = new SqlCommand("Select * from Products", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var p = new Product
                    {
                        Id = (int)dr["ProductId"],
                        Name = dr["ProductName"].ToString(),
                        Price = (decimal?)dr["UnitPrice"],
                        Stock = (short?)dr["UnitsInStock"]
                    };
                    products.Add(p);
                }
            }
            return View(products);
        }
    }
}
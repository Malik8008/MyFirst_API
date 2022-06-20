using FirstAPI.DAL;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //private List<Product> products = new List<Product>()
        //{
        //    new Product
        //    {
        //        Id = 1,
        //        Name = "Cola",
        //        Price = 2,
        //    },
        //    new Product
        //    {
        //        Id=2,
        //        Name = "BMW",
        //        Price= 30000,
        //    },
        //    new Product
        //    {
        //        Id=3,
        //        Name = "HQD",
        //        Price= 27
        //    },
        //    new Product {
        //        Id=4,
        //        Name="Phone",
        //        Price= 2010
        //    }

        //};


        //[Route("get")]
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(p=>p.Id==id);
            if (product == null) return NotFound();
            //return NotFound();
            return Ok(product);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return Ok(_context.Products.ToList());
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPut]
        public IActionResult Edit(Product product)
        {
            Product existed = _context.Products.FirstOrDefault(p=>p.Id==product.Id);
            if (existed == null) return NotFound();

            _context.Entry(existed).CurrentValues.SetValues(product);
            _context.SaveChanges();
            return Ok(existed);
            
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}

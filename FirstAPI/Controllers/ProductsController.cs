using FirstAPI.DAL;
using FirstAPI.DTOs.ProductDTOs;
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
            List<Product> products = await _context.Products.Where(p => p.DisplayStatus == true).ToListAsync();
            ProductGetAllDto model = new()
            {
                ProductList = products.Select(p => new ProductListItem()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                
                }).ToList(),

                TotalCount = products.Count
            };
            return Ok(model);
        }

        [HttpPost("create")]
        public IActionResult Create(ProductPostDTO productDto)
        {
            Product product = new()
            {
                Name = productDto.Name,
                Price = productDto.Price,   
                DisplayStatus = productDto.DisplayStatus
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }


        [HttpPut("edit")]
        public IActionResult Edit(Product product)
        {
            Product existed = _context.Products.FirstOrDefault(p=>p.Id==product.Id);
            if (existed == null) return NotFound();

            existed.Name=product.Name;  
            existed.Price=product.Price;    

            //_context.Entry(existed).CurrentValues.SetValues(product);
            _context.SaveChanges();
            return Ok(existed);
            
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPatch("change/{id}")]
        public IActionResult ChangeStatus(int id, string statusStr)
        {
            Product product = _context.Products.Find(id);
            if (product == null) return NotFound();
            bool status;
            bool result = bool.TryParse(statusStr, out status);

            if (!result) return BadRequest();


            product.DisplayStatus = status;
            _context.SaveChanges();
            return Ok();
        }
    }
}

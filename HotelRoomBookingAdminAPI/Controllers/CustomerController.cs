using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoomBookingAdminAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomBookingAdminAPI.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataDBContext _context;

        public CustomerController(DataDBContext context)
        {
            _context = context;
        }

        //DataDBContext context = new DataDBContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await _context.Customers.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var c = await _context.Customers.FindAsync(id);

            if (c == null)
            {
                return NotFound();
            }
            return c;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Customer>>> Post([FromBody]Customer ctr)
        {
            _context.Customers.Add(ctr);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = ctr.CustomerId }, ctr);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(int id ,[FromBody]Brand newbrand)
        //{
        //    var brand = await context.Brand.FindAsync(id);

        //    if (brand == null)
        //    {
        //        return NotFound();
        //    }
        //    brand.BrandName = newbrand.BrandName;
        //    brand.BrandDescription = newbrand.BrandDescription;

        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]Customer ctr)
        {

            if (id != ctr.CustomerId)
            {
                return BadRequest();
            }
            //brand.BrandName = newbrand.BrandName;
            //brand.BrandDescription = newbrand.BrandDescription;
            _context.Entry(ctr).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var ctr = await _context.Customers.FindAsync(id);

            if (ctr == null)
            {
                return NotFound();
            }
            else
            {
                _context.Customers.Remove(ctr);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}
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
    public class BookingController : ControllerBase
    {
        private readonly DataDBContext _context;

        public BookingController(DataDBContext context)
        {
            _context = context;
        }
        //DataDBContext context = new DataDBContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> Get()
        {
            return await _context.Bookings.ToListAsync();
        }


        [HttpGet("{id}")]
            public async Task<ActionResult<Booking>> Get(int id)
            {
                var c = await _context.Bookings.FindAsync(id);

                if (c == null)
                {
                    return NotFound();
                }
                return c;
            }

            [HttpPost]
            public async Task<ActionResult<IEnumerable<Booking>>> Post([FromBody]Booking ctr)
            {
                _context.Bookings.Add(ctr);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = ctr.BookingId }, ctr);
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
            public async Task<ActionResult> Put(int id, [FromBody]Booking ctr)
            {

                if (id != ctr.BookingId)
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
            public async Task<ActionResult<Booking>> Delete(int id)
            {
                var ctr = await _context.Bookings.FindAsync(id);

                if (ctr == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Bookings.Remove(ctr);
                    await _context.SaveChangesAsync();
                }
                return NoContent();
            }
    }
}
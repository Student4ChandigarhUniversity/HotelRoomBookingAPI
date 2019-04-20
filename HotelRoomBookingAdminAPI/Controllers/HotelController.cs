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
    public class HotelController : ControllerBase
    {
        private readonly DataDBContext _context;

        public HotelController(DataDBContext context)
        {
            _context = context;
        }

        //DataDBContext context = new DataDBContext();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var hotel = await _context.Hotels.ToListAsync();
            return Ok(hotel);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    _context.Hotels.Add(hotel);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = hotel.HotelId }, hotel);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            
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
        public async Task<IActionResult> Put(int? id , [FromBody]Hotel hotel)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != hotel.HotelId)
            {
                return BadRequest();
            }
            //brand.BrandName = newbrand.BrandName;
            //brand.BrandDescription = newbrand.BrandDescription;
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
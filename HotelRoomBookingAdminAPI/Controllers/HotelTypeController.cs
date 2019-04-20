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
    public class HotelTypeController : ControllerBase
    {
        private readonly DataDBContext _context;

        public HotelTypeController(DataDBContext context)
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
            var hoteltype =   await _context.HotelTypes.ToListAsync();
            return Ok(hoteltype);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            try
            {
                var hotelType = await _context.HotelTypes.FindAsync(id);

                if (hotelType == null)
                {
                    return NotFound();
                }
                return Ok(hotelType);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HotelType hotelType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                
            }
            else
            {
                try
                {
                    _context.HotelTypes.Add(hotelType);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = hotelType.HotelTypeId }, hotelType);
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
        public async Task<ActionResult> Put(int? id, [FromBody]HotelType hotelType)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id != hotelType.HotelTypeId)
            {
                return BadRequest();
            }
            //brand.BrandName = newbrand.BrandName;
            //brand.BrandDescription = newbrand.BrandDescription;
            _context.Entry(hotelType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotelType = await _context.HotelTypes.FindAsync(id);

            if (hotelType == null)
            {
                return NotFound();
            }

             _context.HotelTypes.Remove(hotelType);
             await _context.SaveChangesAsync();
             return Ok(hotelType);
        }
    }
}
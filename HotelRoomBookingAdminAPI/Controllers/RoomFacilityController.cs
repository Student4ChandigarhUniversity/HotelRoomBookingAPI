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
    public class RoomFacilityController : ControllerBase
    {

        private readonly DataDBContext _context;

        public RoomFacilityController(DataDBContext context)
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

            var rf =  await _context.RoomFacilities.ToListAsync();
            return Ok(rf);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var roomFacility = await _context.RoomFacilities.FindAsync(id);

            if (roomFacility == null)
            {
                return NotFound();
            }
            return Ok(roomFacility);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RoomFacility roomFacility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            else
            {
                try
                {
                    _context.RoomFacilities.Add(roomFacility);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = roomFacility.RoomFacilityId }, roomFacility);
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
        public async Task<IActionResult> Put(int? id, [FromBody]RoomFacility roomFacility)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id != roomFacility.RoomFacilityId)
            {
                return BadRequest();
            }
            //brand.BrandName = newbrand.BrandName;
            //brand.BrandDescription = newbrand.BrandDescription;
            _context.Entry(roomFacility).State = EntityState.Modified;
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


            var roomFacility = await _context.RoomFacilities.FindAsync(id);

            if (roomFacility == null)
            {
                return NotFound();
            }

            _context.RoomFacilities.Remove(roomFacility);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
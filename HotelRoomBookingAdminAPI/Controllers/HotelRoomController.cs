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
    public class HotelRoomController : ControllerBase
    {
        private readonly DataDBContext _context;

        public HotelRoomController(DataDBContext context)
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
            var hotelRoom =  await _context.HotelRooms.ToListAsync();
            return Ok(hotelRoom);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var hotelRoom = await _context.HotelRooms.FindAsync(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }
            return Ok(hotelRoom);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HotelRoom hotelRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            else
            {
                try
                {
                    _context.HotelRooms.Add(hotelRoom);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = hotelRoom.RoomId }, hotelRoom);
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
        public async Task<IActionResult> Put(int? id, [FromBody]HotelRoom hotelRoom)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            if (id != hotelRoom.RoomId)
            {
                return BadRequest();
            }
            //brand.BrandName = newbrand.BrandName;
            //brand.BrandDescription = newbrand.BrandDescription;
            _context.Entry(hotelRoom).State = EntityState.Modified;
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

            var hotelRoom = await _context.HotelRooms.FindAsync(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
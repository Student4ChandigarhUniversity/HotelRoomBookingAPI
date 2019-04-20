﻿using System;
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
    public class UserDetailController : ControllerBase
    {

        private readonly DataDBContext context;

        public UserDetailController(DataDBContext _context)
        {
            context = _context;
        }
        //DataDBContext context = new DataDBContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> Get()
        {
            return await context.UserDetails.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> Get(int id)
        {
            var hotelRoom = await context.UserDetails.FindAsync(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }
            return hotelRoom;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserDetail>>> Post([FromBody]UserDetail hotelRoom)
        {
            context.UserDetails.Add(hotelRoom);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hotelRoom.UserId }, hotelRoom);
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
        public async Task<ActionResult> Put(int id, [FromBody]UserDetail hotelRoom)
        {

            if (id != hotelRoom.UserId)
            {
                return BadRequest();
            }
            //brand.BrandName = newbrand.BrandName;
            //brand.BrandDescription = newbrand.BrandDescription;
            context.Entry(hotelRoom).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDetail>> Delete(int id)
        {
            var hotelRoom = await context.UserDetails.FindAsync(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }
            else
            {
                context.UserDetails.Remove(hotelRoom);
                await context.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}
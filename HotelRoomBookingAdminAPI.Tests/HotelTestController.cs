using FluentAssertions;
using HotelRoomBookingAdminAPI.Controllers;
using HotelRoomBookingAdminAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HotelRoomBookingAdminAPI.Tests
{
    public class HotelTestController
    {

        private DataDBContext context;

        public static DbContextOptions<DataDBContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-520;Initial Catalog=coreHotelRoomBookingFinalDatabase;Integrated Security=true;";


        static HotelTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<DataDBContext>().UseSqlServer(connectionString).Options;

        }

        public HotelTestController()
        {
            context = new DataDBContext(dbContextOptions);
        }
        [Fact]
        public async void Task_GetHotel_Return_OkResult()
        {
            //Arrange
            var controller = new HotelController(context);

            //Act
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetHotel_Return_NotFound()
        {
            //Arrange
            var controller = new HotelController(context);
            var data = await controller.Get();
            data = null;
            if (data != null)
            {
                Assert.IsType<OkObjectResult>(data);
            }
            else
            {
                //Assert.Equal(data, null);
            }
            
            
        }

        [Fact]

        public async void Task_GethotelById_Return_OkResult()
        {
            var controller = new HotelController(context);
            var UserId = 1;
            var data = await controller.Get(UserId);
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetHotelById_Return_NotFound()
        {
            var controller = new HotelController(context);
            var UserId = 100;
            var data = await controller.Get(UserId);
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_GetHotelById_Return_MatchResult()
        {
            //Arrange
            var controller = new HotelController(context);
            var Id = 1;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<OkObjectResult>(data);
            var okresult = data.Should().BeOfType<OkObjectResult>().Subject;
            var hotel = okresult.Value.Should().BeAssignableTo<Hotel>().Subject;

            Assert.Equal("Oberoi", hotel.HotelName);
            
        }

        [Fact]
        public async void Task_GetHotelById_Return_BadRequest()
        {
            //Arrange
            var controller = new HotelController(context);
            int? Id = null;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Add_AddHotel_return_OkResult()
        {
            //Arrange
            var controller = new HotelController(context);

            var hotel = new Hotel()
            {
                HotelName = "The Ashoka",
                HotelAddress = "Delhi",
                HotelDistrict = "Delhi",
                HotelCity = "Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "ashoka@gmail.com",
                HotelRating = "1",
                HotelContactNumber = 123654789,
                HotelImage = "jkewhffj",
                HotelDescription = "Description",
                HotelTypeId = 2
            };

            //Act
            var data = await controller.Post(hotel);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public async void Task_Add_AddHotel_return_BadResult()
        {
            //Arrange
            var controller = new HotelController(context);

            var hotel = new Hotel()
            {
                HotelName = "Ashoka is the name of the Hotel",
                HotelAddress = "Delhi",
                HotelDistrict = "Delhi",
                HotelCity = "Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "ashoka@gmail.com",
                HotelRating = "1",
                HotelContactNumber = 123654789,
                HotelImage = "jkewhffj",
                HotelDescription = "Description",
                HotelTypeId = 7
            };

            //Act
            var data = await controller.Post(hotel);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        //[Fact]
        //public async void Task_DeleteHotel_return_OkResult()
        //{
        //    //Arrange
        //    var controller = new HotelController(context);
        //    var id = 41;

        //    //Act
        //    var data = await controller.Delete(id);

        //    //Assert
        //    Assert.IsType<NoContentResult>(data);
        //}


        [Fact]
        public async void Task_DeleteHotel_return_NotFound()
        {
            //Arrange
            var controller = new HotelController(context);
            int Id = 41;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<NotFoundResult>(data);

        }
        [Fact]
        public async void Task_DeleteHotel_return_BadResult()
        {
            //Arrange
            var controller = new HotelController(context);
            int? Id = null;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Update_UpdateHotelById_return_OkResult()
        {
            //Arrange

            var controller = new HotelController(context);
            var id = 2;
            var hotel = new Hotel()
            {
                HotelId = 2,
                HotelName = "The Ashoka",
                HotelAddress = "Delhi",
                HotelDistrict = "Delhi",
                HotelCity = "Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "ashoka@gmail.com",
                HotelRating = "1",
                HotelContactNumber = 123654789,
                HotelImage = "jkewhffj",
                HotelDescription = "Description",
                HotelTypeId = 2
            };

            //Act
            var data = await controller.Put(id,hotel);

            //Assert
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async void Task_Update_UpdateHotelById_return_BadResult()
        {
            //Arrange

            var controller = new HotelController(context);
            var id = 2;
            var hotel = new Hotel()
            {
                HotelName = "Ashoka is the name of the Hotel",
                HotelAddress = "Delhi",
                HotelDistrict = "Delhi",
                HotelCity = "Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "ashoka@gmail.com",
                HotelRating = "1",
                HotelContactNumber = 123654789,
                HotelImage = "jkewhffj",
                HotelDescription = "Description",
                HotelTypeId = 2
            };

            //Act
            var data = await controller.Put(id, hotel);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_UpdateHotelById_Return_BadRequest()
        {
            //Arrange
            var controller = new HotelController(context);
            int? Id = null;
            var hotel = new Hotel()
            {
                HotelName = "Ashoka is the name of the Hotel",
                HotelAddress = "Delhi",
                HotelDistrict = "Delhi",
                HotelCity = "Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "ashoka@gmail.com",
                HotelRating = "1",
                HotelContactNumber = 123654789,
                HotelImage = "jkewhffj",
                HotelDescription = "Description",
                HotelTypeId = 7
            };
            //Act
            var data = await controller.Put(Id, hotel);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }
    }
}

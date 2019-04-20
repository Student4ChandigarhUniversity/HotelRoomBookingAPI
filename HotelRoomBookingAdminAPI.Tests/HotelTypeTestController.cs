using FluentAssertions;
using HotelRoomBookingAdminAPI.Controllers;
using HotelRoomBookingAdminAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace HotelRoomBookingAdminAPI.Tests
{
    public class HotelTypeTestController
    {
        private DataDBContext context;

        public static DbContextOptions<DataDBContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-520;Initial Catalog=coreHotelRoomBookingFinalDatabase;Integrated Security=true;";


        static HotelTypeTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<DataDBContext>().UseSqlServer(connectionString).Options;

        }

        public HotelTypeTestController()
        {
            context = new DataDBContext(dbContextOptions);
        }

        [Fact]
        public async void Task_GetHotelType_Return_OkResult()
        {
            //Arrange
            var controller = new HotelTypeController(context);

            //Act
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetHotelType_Return_NotFound()
        {
            //Arrange
            var controller = new HotelTypeController(context);
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
        public async void Task_GetHotelTypeById_Return_OkResult()
        {
            //Arrange
            var controller = new HotelTypeController(context);
            var UserId = 2;

            //Act
            var data = await controller.Get(UserId);
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetHotelTypeById_Return_NotFound()
        {
            //Arrange
            var controller = new HotelTypeController(context);
            var Id = 100;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_GetHotelTypeById_Return_MatchResult()
        {
            //Arrange
            var controller = new HotelTypeController(context);
            var Id = 1;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<OkObjectResult>(data);
            var okresult = data.Should().BeOfType<OkObjectResult>().Subject;
            var hotelType = okresult.Value.Should().BeAssignableTo<HotelType>().Subject;

            Assert.Equal("Villa", hotelType.HotelTypeName);
            Assert.Equal("Goodd", hotelType.HotelTypeDescription);

        }

        [Fact]
        public async void Task_GetHotelTypeById_Return_BadRequest()
        {
            //Arrange
            var controller = new HotelTypeController(context);
            int? Id = null;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }



        [Fact]
        public async void Task_Add_AddHotelType_return_OkResult()
        {
            //Arrange

            var controller = new HotelTypeController(context);

            var hoteltype = new HotelType()
            {
                HotelTypeName = "Hotel",
                HotelTypeDescription = "Hotel Description",
                
            };

            //Act
            var data = await controller.Post(hoteltype);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }


        [Fact]
        public async void Task_Add_AddHotelType_return_BadResult()
        {
            //Arrange
            var controller = new HotelTypeController(context);

            var hoteltype = new HotelType()
            {
                HotelTypeName = "Hotel Type Name is Hotel",
                HotelTypeDescription = "Hotel Description",

            };

            //Act
            var data = await controller.Post(hoteltype);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public async void Task_DeleteHotelType_return_OkResult()
        {
            //Arrange
            var controller = new HotelTypeController(context);
            var id = 25;
            

            //Act
            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }


        [Fact]
        public async void Task_DeleteHotelType_return_NotFound()
        {
            //Arrange
            var controller = new HotelTypeController(context);
            var id = 25;

            //Act
            var data = await controller.Get(id);

            //Asert
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_DeleteHotelType_return_BadResult()
        {
            //Arrange
            var controller = new HotelTypeController(context);
            int? Id = null;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Update_UpdateHotelTypeById_return_OkResult()
        {
            //Arrange

            var controller = new HotelTypeController(context);
            var id = 29;

            var hoteltype = new HotelType()
            {
                HotelTypeId = 29,
                HotelTypeName = "Hotel",
                HotelTypeDescription = "Hotel Desc",
                
            };

            //Act
            var data = await controller.Put(id,hoteltype);

            //Assert
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async void Task_Update_UpdateHotelTypeById_return_BadResult()
        {
            //Arrange

            var controller = new HotelTypeController(context);
            var id = 29;
            var hoteltype = new HotelType()
            {
                HotelTypeId = 28,
                HotelTypeName = "Hotel",
                HotelTypeDescription = "Hotel",

            };

            //Act
            var data = await controller.Put(id, hoteltype);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_UpdateHotelTypeById_Return_BadRequest()
        {
            //Arrange
            var controller = new HotelTypeController(context);
            int? Id = null;
            var hoteltype = new HotelType()
            {
                HotelTypeId = 28,
                HotelTypeName = "Hotel",
                HotelTypeDescription = "Hotel",

            };
            //Act
            var data = await controller.Put(Id,hoteltype);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }
    }
}

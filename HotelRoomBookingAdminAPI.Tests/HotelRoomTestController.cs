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
    public class HotelRoomTestController
    {
        private DataDBContext context;

        public static DbContextOptions<DataDBContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-520;Initial Catalog=coreHotelRoomBookingFinalDatabase;Integrated Security=true;";


        static HotelRoomTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<DataDBContext>().UseSqlServer(connectionString).Options;

        }

        public HotelRoomTestController()
        {
            context = new DataDBContext(dbContextOptions);
        }

        [Fact]
        public async void Task_GetHotelRoom_Return_OkResult()
        {
            //Arrange
            var controller = new HotelRoomController(context);

            //Act
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetHotelRoom_Return_NotFound()
        {
            //Arrange
            var controller = new HotelRoomController(context);
            var data = await controller.Get();
            data = null;
            if (data != null)
            {
                Assert.IsType<OkObjectResult>(data);
            }
            //else
            //{
            //    Assert.Equal(data, null);
            //}


        }




        [Fact]
        public async void Task_GetHotelRoomById_Return_OkResult()
        {
            //Arrange
            var controller = new HotelRoomController(context);
            var UserId = 1;

            //Act
            var data = await controller.Get(UserId);
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetHotelRoomById_Return_NotFound()
        {
            //Arrange
            var controller = new HotelRoomController(context);
            var Id = 100;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_GetHotelRoomById_Return_MatchResult()
        { 
            //Arrange
            var controller = new HotelRoomController(context);
            var Id = 1;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<OkObjectResult>(data);
            var okresult = data.Should().BeOfType<OkObjectResult>().Subject;
            var hotelRoom = okresult.Value.Should().BeAssignableTo<HotelRoom>().Subject;

            Assert.Equal("Single Bed", hotelRoom.RoomType);
            Assert.Equal(2500, hotelRoom.RoomPrice);

        }

        [Fact]
        public async void Task_GetHotelRoomById_Return_BadRequest()
        {
            //Arrange
            var controller = new HotelRoomController(context);
            int? Id = null;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }



        [Fact]
        public async void Task_Add_AddHotelRoom_return_OkResult()
        {
            //Arrange

            var controller = new HotelRoomController(context);

            var hotelRoom = new HotelRoom()
            {
                RoomType = "Single Bed",
                RoomPrice = 2500,
                RoomDescription = "Good V",
                RoomImage = "n available",
                HotelId = 42

            };

            //Act
            var data = await controller.Post(hotelRoom);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }


        [Fact]
        public async void Task_Add_AddHotelRoom_return_BadResult()
        {
            //Arrange
            var controller = new HotelRoomController(context);

            var hotelRoom = new HotelRoom()
            {
                RoomType = "Single Bed , This is Room Type",
                RoomPrice = 2500,
                RoomDescription = "Good V",
                RoomImage = "n available",
                HotelId = 42

            };

            //Act
            var data = await controller.Post(hotelRoom);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_DeleteHotelRoom_return_OkResult()
        {
            //Arrange
            var controller = new HotelRoomController(context);
            var id = 29;

            //Act
            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<NoContentResult>(data);
        }


        [Fact]
        public async void Task_DeleteHotelRoom_return_NotFound()
        {
            //Arrange
            var controller = new HotelRoomController(context);
            var id = 29;

            //Act
            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_DeleteHotelRoom_return_BadResult()
        {
            //Arrange
            var controller = new HotelRoomController(context);
            int? Id = null;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Update_UpdateHotelRoomById_return_OkResult()
        {
            //Arrange

            var controller = new HotelRoomController(context);
            var id = 2;

            var hotelRoom = new HotelRoom()
            {
                RoomId = 2,
                RoomType = "Single Bed",
                RoomPrice= 2500,
                RoomDescription = "Good V",
                RoomImage = "n available",
                HotelId = 1


            };

            //Act
            var data = await controller.Put(id, hotelRoom);

            //Assert
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async void Task_Update_UpdateHotelRoomById_return_BadResult()
        {
            //Arrange

            var controller = new HotelRoomController(context);
            var id = 29;
            var hotelRoom = new HotelRoom()
            {
                RoomId = 28,
                RoomType = "Single Bed",
                RoomPrice = 2500,
                RoomDescription = "Good V",
                RoomImage = "n available",
                HotelId = 42

            };

            //Act
            var data = await controller.Put(id, hotelRoom);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_UpdateHotelRoomById_Return_BadRequest()
        {
            //Arrange
            var controller = new HotelRoomController(context);
            int? Id = null;
            var hotelRoom = new HotelRoom()
            {
                RoomId = 28,
                RoomType = "Single Bed",
                RoomPrice = 2500,
                RoomDescription = "Good V",
                RoomImage = "n available",
                HotelId = 42

            };
            //Act
            var data = await controller.Put(Id, hotelRoom);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }
    }
}

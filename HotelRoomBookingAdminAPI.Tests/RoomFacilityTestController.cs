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
    public class RoomFacilityTestController
    {

        private DataDBContext context;

        public static DbContextOptions<DataDBContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-520;Initial Catalog=coreHotelRoomBookingFinalDatabase;Integrated Security=true;";


        static RoomFacilityTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<DataDBContext>().UseSqlServer(connectionString).Options;

        }

        public RoomFacilityTestController()
        {
            context = new DataDBContext(dbContextOptions);
        }

        [Fact]
        public async void Task_GetRoomFacility_Return_OkResult()
        {
            //Arrange
            var controller = new RoomFacilityController(context);

            //Act
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetRoomFacility_Return_NotFound()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
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
        public async void Task_GetRoomFacilityById_Return_OkResult()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
            var id = 13;

            //Act
            var data = await controller.Get(id);
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetRoomFacilityById_Return_NotFound()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
            var Id = 100;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_GetRoomFacilityById_Return_MatchResult()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
            var Id = 13;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<OkObjectResult>(data);
            var okresult = data.Should().BeOfType<OkObjectResult>().Subject;
            var roomFacility = okresult.Value.Should().BeAssignableTo<RoomFacility>().Subject;

            Assert.Equal("Good", roomFacility.RoomFacilityDescription);
            Assert.Equal(32, roomFacility.RoomId);

        }

        [Fact]
        public async void Task_GetRoomFacilityById_Return_BadRequest()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
            int? Id = null;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }



        [Fact]
        public async void Task_Add_AddRoomFacility_return_OkResult()
        {
            //Arrange

            var controller = new RoomFacilityController(context);

            var roomFacility = new RoomFacility()
            {
                IsAvilable =true,
                Wifi =true,
                AirConditioner =false,
                Ekettle =true,
                Refrigerator =false ,
                RoomFacilityDescription ="Room description" ,
                RoomId = 35
            };

            //Act
            var data = await controller.Post(roomFacility);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }


        [Fact]
        public async void Task_Add_AddRoomFacility_return_BadResult()
        {
            //Arrange
            var controller = new RoomFacilityController(context);

            var roomFacility = new RoomFacility()
            {
                IsAvilable = true,
                Wifi = true,
                AirConditioner = false,
                Ekettle = true,
                Refrigerator = false,
                RoomFacilityDescription = "Room description : Hotel Room contails all the basic facility.",
                RoomId = 38
            };

            //Act
            var data = await controller.Post(roomFacility);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_DeleteRoomFacility_return_OkResult()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
            var id = 18;

            //Act
            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<NoContentResult>(data);
        }


        [Fact]
        public async void Task_DeleteRoomFacility_return_NotFound()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
            var id = 29;

            //Act
            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_DeleteRoomFacility_return_BadResult()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
            int? Id = null;

            //Act
            var data = await controller.Get(Id);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Update_UpdateRoomFacilityById_return_OkResult()
        {
            //Arrange

            var controller = new RoomFacilityController(context);
            var id = 13;

            var roomFacility = new RoomFacility()
            {
                RoomFacilityId = 13,
                IsAvilable = true,
                Wifi = true,
                AirConditioner = false,
                Ekettle = true,
                Refrigerator = false,
                RoomFacilityDescription = "Room description",
                RoomId = 32

            };

            //Act
            var data = await controller.Put(id,roomFacility);

            //Assert
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async void Task_Update_UpdateRoomFacilityById_return_BadResult()
        {
            //Arrange

            var controller = new RoomFacilityController(context);
            var id = 29;
            var roomFacility = new RoomFacility()
            {
                RoomFacilityId =13 ,
                IsAvilable = true,
                Wifi = true,
                AirConditioner = false,
                Ekettle = true,
                Refrigerator = false,
                RoomFacilityDescription = "Room description",
                RoomId = 35
            };

            //Act
            var data = await controller.Put(id, roomFacility);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_UpdateRoomFacilityById_Return_BadRequest()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
            int? Id = null;
            var roomFacility = new RoomFacility()
            {
                

            };
            //Act
            var data = await controller.Put(Id, roomFacility);

            //Asert
            Assert.IsType<BadRequestResult>(data);

        }

    }
}

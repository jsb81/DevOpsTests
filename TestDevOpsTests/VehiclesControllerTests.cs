using DevOpsTests.Controllers;
using DevOpsTests.Data;
using DevOpsTests.Models;
using DevOpsTests.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace TestDevOpsTests
{
    public class VehiclesControllerTests
    {
        private List<Vehicle> vehicles;

        public VehiclesControllerTests()
        {
            vehicles = new List<Vehicle>();

            vehicles.Add(new Vehicle()
            {
                Id = 1,
                Model = "Ferrari",
                SerialNumber = "F01",
                Number = 2,
                Wheels = 4
            });

            vehicles.Add(new Vehicle()
            {
                Id = 2,
                Model = "Ducati",
                SerialNumber = "D01",
                Number = 2,
                Wheels = 2
            });
        }

        [Fact(DisplayName ="GetVeichles with two Vehicles Returns two Vehicles")]
        public void GetVehicles_WithTwoVehicles_ReturnsTwoVehicles()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Vehicle>>();
            mockRepository.Setup(repository => repository.ToList())
                .Returns(() => { return this.vehicles; });
            var controller = new VehiclesController(null, mockRepository.Object);   

            // Act
            var response = controller.GetVehicles();

            // Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var okResult = response.Result as OkObjectResult;
            okResult.Value.Should().BeOfType<List<Vehicle>>();
            var vehicles = okResult.Value as List<Vehicle>;
            vehicles.Count.Should().Be(2);
        }

        [Fact(DisplayName = "GetVehicle with matching result returns one Vehicle")]
        public async Task GetVehicle_WithMatchingResult_ReturnsOneVehicle()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Vehicle>>();
            mockRepository.Setup(repository => repository.FindAsync(It.IsAny<int>()))
                .Returns<int>((id) => searchVehicle(id));

            var controller = new VehiclesController(null, mockRepository.Object);

            // Act
            var response = await controller.GetVehicle(1);

            // Assert
            response.Result.Should().BeOfType<OkObjectResult>();
            var okResult = response.Result as OkObjectResult;
            okResult.Value.Should().BeOfType<Vehicle>();
            var vehicle = okResult.Value as Vehicle;
            vehicle.Model.Should().Be("Ferrari");
        }

        private async Task<Vehicle> searchVehicle(int id)
        {
            Task<Vehicle> task = Task.Factory.StartNew(() =>
            {
                return vehicles.SingleOrDefault(vehicle => vehicle.Id == id);
            });

            return await task;
        }

    }
}

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

namespace TestDevOpsTests
{
    public class VehiclesControllerTests
    {
        [Fact(DisplayName ="GetVeichles with two Vehicles Returns two Vehicles")]
        public void GetVehicles_WithTwoVehicles_ReturnsTwoVehicles()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Vehicle>>();
            mockRepository.Setup(repository => repository.ToList())
                .Returns(GetTestVehicles());
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

        #region Mocked Contents Methods
        List<Vehicle> GetTestVehicles()
        {
            var vehicles = new List<Vehicle>();

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

            return vehicles;
        }
        #endregion
    }
}

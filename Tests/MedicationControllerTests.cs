using MedicationAPI.Controller;
using MedicationAPI.Models;
using MedicationAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MedicationAPI.Tests;

public class MedicationControllerTests
{
    private readonly Mock<IMedicationService> _medicationServiceMock;
    private readonly MedicationController _controller;

    public MedicationControllerTests()
    {
        _medicationServiceMock = new Mock<IMedicationService>();
        _controller = new MedicationController(_medicationServiceMock.Object);
    }

    [Fact]
    public async Task GetMedications_ReturnsOkResult()
    {
        // Arrange
        var medications = new List<Medication> { new Medication { Id = 1, Name = "Aspirin", Quantity = 10, CreatedDate = System.DateTime.UtcNow } };
        _medicationServiceMock.Setup(service => service.GetMedicationsAsync()).ReturnsAsync(medications);

        // Act
        var result = await _controller.GetMedications();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<Medication>>(okResult.Value);
        Assert.Single(returnValue);
    }

    [Fact]
    public async Task CreateMedication_ReturnsBadRequest_WhenInvalidModel()
    {
        // Arrange
        var medication = new Medication { Name = "", Quantity = -1 }; // Invalid data

        // Act
        var result = await _controller.CreateMedication(medication);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task DeleteMedication_ReturnsNoContent_WhenSuccess()
    {
        // Arrange
        _medicationServiceMock.Setup(service => service.DeleteMedicationAsync(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteMedication(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}

using MedicationAPI.Controller;
using MedicationAPI.Controller.DTO;
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
        var medications = new List<CreateMedicationDto> { new() { Name = "Aspirin", Quantity = 10 } };
        _medicationServiceMock.Setup(service => service.GetMedicationsAsync()).ReturnsAsync(medications.Select(x => new Medication(x.Name, x.Quantity)));

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
        var medication = new CreateMedicationDto { Name = "", Quantity = -1 }; // Invalid data

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
        var result = await _controller.DeleteMedication(new EntityDto(1));

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}

using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using DogQuiz.Application.BreedManagement.Interfaces;
using DogQuiz.API.Controllers;
using DogQuiz.API.Requests;


namespace DogQuiz.Tests.UnitTests;
public class BreedsControllerTests
{
	private readonly Mock<IBreedFactGeneratorService> _mockFactService;
	private readonly BreedsController _controller;

	public BreedsControllerTests()
	{
		_mockFactService = new Mock<IBreedFactGeneratorService>();
		// Injecting only the mocked service (other parameters can remain null for this specific test)
		_controller = new BreedsController(null, null, _mockFactService.Object);
	}

	[Fact]
	public async Task GetRandomFact_ValidIdWithFact_ReturnsOkWithFact()
	{
		// Arrange
		int breedId = 1;
		string expectedFact = "This is a test fact.";
		_mockFactService.Setup(service => service.GetRandomFactForBreedAsync(breedId))
						.ReturnsAsync(expectedFact);

		// Act
		var result = await _controller.GetRandomFact(breedId);

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		Assert.Equal(expectedFact, okResult.Value);
	}

	[Fact]
	public async Task GetRandomFact_ValidIdNoFact_ReturnsNotFound()
	{
		// Arrange
		int breedId = 2;
		_mockFactService.Setup(service => service.GetRandomFactForBreedAsync(breedId))
						.ReturnsAsync((string?)null);

		// Act
		var result = await _controller.GetRandomFact(breedId);

		// Assert
		Assert.IsType<NotFoundObjectResult>(result);
	}

	[Fact]
	public async Task GetRandomFact_InvalidId_ReturnsBadRequest()
	{
		// Arrange
		int invalidBreedId = 0; // Invalid ID

		// Act
		var result = await _controller.GetRandomFact(invalidBreedId);

		// Assert
		var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
		Assert.Equal("Breed ID must be greater than zero.", badRequestResult.Value);
	}

	[Fact]
	public async Task GetRandomFact_ServiceThrowsException_ReturnsServerError()
	{
		// Arrange
		int breedId = 3;
		_mockFactService.Setup(service => service.GetRandomFactForBreedAsync(breedId))
						.ThrowsAsync(new System.Exception("Something went wrong."));

		// Act
		var result = await _controller.GetRandomFact(breedId);

		// Assert
		var serverErrorResult = Assert.IsType<ObjectResult>(result);
		Assert.Equal(500, serverErrorResult.StatusCode);
		Assert.Equal("An unexpected error occurred.", serverErrorResult.Value);
	}

	[Fact]
	public void ToBreed_MapsCorrectly()
	{
		// Arrange
		var request = new CreateBreedRequest
		{
			Name = "Golden Retriever",
			AdditionalNames = new List<string> { "Retriever", "Golden" },
			Description = "A friendly and intelligent breed.",
			Difficulty = 2,
			BreedTags = new List<string> { "Friendly", "Family" }
		};

		// Act
		var breed = request.ToBreed();

		// Assert
		Assert.Equal("Golden Retriever", breed.Name);
		Assert.Equal(2, breed.Difficulty);
		Assert.Equal("A friendly and intelligent breed.", breed.Description);
		Assert.Collection(breed.AdditionalNames,
			name => Assert.Equal("Retriever", name.Name),
			name => Assert.Equal("Golden", name.Name));
		Assert.Collection(breed.BreedTags,
			tag => Assert.Equal("Friendly", tag.Name),
			tag => Assert.Equal("Family", tag.Name));
	}

}
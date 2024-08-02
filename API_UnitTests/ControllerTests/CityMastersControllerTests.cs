namespace API_UnitTests.ControllerTests
{
    public class CityMastersControllerTests
    {
        private readonly DbContextOptions<AppDBContext> _options;

        public CityMastersControllerTests()
        {
            // Set up the in-memory database context options
            _options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Seed the in-memory database
            using var context = new AppDBContext(_options);
            context.CityMasters.AddRange(
                new CityMaster { CityID = 1, StateID = 2, CityName = "Jaipur" },
                new CityMaster { CityID = 2, StateID = 2, CityName = "Ajmer" },
                new CityMaster { CityID = 3, StateID = 2, CityName = "Udaipur" }
            );
            context.SaveChanges();
        }

        [Fact]
        public async Task GetCities_ReturnsOkResult_WithListOfCities()
        {
            // Arrange
            using var context = new AppDBContext(_options);
            var controller = new CityMasterController(context);

            // Act
            var result = await controller.GetCities();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var cities = Assert.IsAssignableFrom<IEnumerable<CityMaster>>(okResult.Value);
            Assert.Equal(3, cities.Count());
        }
    }


}

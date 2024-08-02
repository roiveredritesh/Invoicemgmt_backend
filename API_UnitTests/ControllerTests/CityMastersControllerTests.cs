using AutoFixture;

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

            // Auto-generate a list of CityMaster objects
            var fixture = new Fixture();
            fixture.Customize<CityMaster>(c => c.Without(x => x.CityID));
            var cityMasters = fixture.CreateMany<CityMaster>(3).ToList();

            // Seed the in-memory database
            using var context = new AppDBContext(_options);
            context.CityMasters.AddRange(cityMasters);
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

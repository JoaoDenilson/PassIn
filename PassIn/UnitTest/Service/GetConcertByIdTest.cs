using NSubstitute;
using NSubstitute.ReturnsExtensions;
using PassIn.Application.UseCases.Events.GetById;
using PassIn.Communication.Responses;
using PassIn.Infrastructure.Entities;
using PassIn.Infrastructure.Repository;
namespace UnitTest.Service
{
    [TestClass]
    public sealed partial class GetConcertByIdTest
    {

        [TestMethod]
        public async Task GetEventByIdNotFound()
        {
            // Arrange
            var getConcertByIdUseCase = Substitute.For<IGetConcertByIdUseCase>();
            Guid guid = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f55");

            // Act
            var result = await getConcertByIdUseCase.Execute(guid).ConfigureAwait(false);

            // Assert
            Assert.IsNull(result);
        }

        [DataTestMethod]
        [DynamicData(nameof(DataSources.GetEventByIdDataSource), typeof(DataSources))]
        public async Task GetEventById(Concert? entityConcert, ResponseConcertJson? responseConcertJson)
        {
            // Arrange
            var getConcertByIdUseCase = Substitute.For<IGetConcertByIdUseCase>();
            var concertRepository = Substitute.For<IConcertRepository>();
            Guid guid = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f55");

            _ =  concertRepository.GetConcertById(guid).Returns(entityConcert);
            _ = getConcertByIdUseCase.Execute(guid).Returns(responseConcertJson);

            // Act
            var result = await getConcertByIdUseCase.Execute(guid).ConfigureAwait(false);

            // Assert
            result.Equals(responseConcertJson);
        }        
    }
}
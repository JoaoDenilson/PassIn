using PassIn.Infrastructure.Repository;
using NSubstitute;
using PassIn.Infrastructure.Entities;
using PassIn.Communication.Responses;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Communication.Requests;
using PassIn.Infrastructure;

namespace UnitTest.Service
{
    [TestClass]
    public sealed partial class RegisterConcertTest
    {
        [DataTestMethod]
        [DynamicData(nameof(DataSources.RegisterConcertDataSource), typeof(DataSources))]
        public void RegisterConcert(Concert concert, RequestConcertJson requestConcertJson,
            ResponseRegisteredJson? responseRegisteredJson)
        {
            // Arrange
            var concertRepository = Substitute.For<IConcertRepository>();
            var registerConcert = Substitute.For<IRegisterConcertUseCase>();

            _ = concertRepository.CreateConcert(concert).Returns(concert);

            _ = registerConcert.Execute(requestConcertJson).Returns(responseRegisteredJson);

            // Act
            var result = registerConcert.Execute(requestConcertJson);

            // Assert
            result.Equals(responseRegisteredJson);
        }
    }
}

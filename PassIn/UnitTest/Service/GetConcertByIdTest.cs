using NSubstitute;
using PassIn.Application.UseCases.Events.GetById;
using PassIn.Infrastructure.Entities;
using PassIn.Infrastructure.Repository;
namespace UnitTest.Service
{
    [TestClass]
    public class GetConcertByIdTest
    {
        private IGetConcertByIdUseCase getConcertByIdUseCase;
        private IConcertRepository concertRepository;

        [TestInitialize]
        public void Setup()
        {
            this.getConcertByIdUseCase = Substitute.For<IGetConcertByIdUseCase>();
            this.concertRepository = Substitute.For<IConcertRepository>();;
    }
        [TestMethod]
        public void GetEventById()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            var entityEvent = new Concert
            {
                Id = guid,
                Details = "Test",
                Title = "Event-test",
                Maximum_Attendees = 10,
                Slug = "event-test",
                Attendees = new List<Attendee>()
                {
                    new Attendee {
                        Id = Guid.NewGuid(),
                        Name = "Test",
                        Email = "test@test.com",
                        Event_Id = guid,
                        Created_At = DateTime.Now,
                     },
                },
            };

            _= concertRepository.GetConcertById(guid).Returns(entityEvent);

            // Act
            var result = getConcertByIdUseCase.Execute(guid);

            // Assert
            var resultTest = result.Result;
            Assert.IsNotNull(result);
        }
    }
}
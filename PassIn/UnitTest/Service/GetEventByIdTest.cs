using NSubstitute;
using PassIn.Application.UseCases.Events.GetById;
using PassIn.Infrastructure.Entities;
using PassIn.Infrastructure.Repository;
namespace UnitTest.Service
{
    [TestClass]
    public class GetEventByIdTest
    {
        private IGetEventByIdUseCase getEventByIdUseCase;
        private IEventRepository eventRepository;

        [TestInitialize]
        public void Setup()
        {
            this.getEventByIdUseCase = Substitute.For<IGetEventByIdUseCase>();
            this.eventRepository = Substitute.For<IEventRepository>();;
    }
        [TestMethod]
        public void GetEventById()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            var entityEvent = new Event
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

            _= eventRepository.GetEventById(guid).Returns(entityEvent);

            // Act
            var result = getEventByIdUseCase.Execute(guid);

            // Assert
            var resultTest = result.Result;
            Assert.IsNotNull(result);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PassIn.Application.UseCases.Attendees.GetAllByEventId;
using PassIn.Communication.Responses;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace UnitTests.Application
{
    [TestClass]
    public class GetAllAttendeesByEventIdUseCaseTests
    {
        [TestMethod]
        //[DataRow(12315)]
        public void GetAllAttendeesByEventId()
        {
            // Arrange
            Guid guidEvent = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709");
            Guid guidAttendee = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857710");
            Guid guidCheckIn = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857711");
            ResponseAllAttendeesJson expected = new ResponseAllAttendeesJson();

            var ev = Substitute.For<IPassInDBContext>();

            var at = new GetAllAttendeesByEventIdUseCase(ev);

            // Act
            var result = at.Execute(guidEvent);

            // Assert
            result.Equals(expected);
        }
    }
}
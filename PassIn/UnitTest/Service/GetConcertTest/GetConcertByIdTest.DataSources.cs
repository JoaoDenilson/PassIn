using PassIn.Communication.Responses;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Service
{
    public sealed partial class GetConcertByIdTest
    {
        private static class DataSources
        {
            public static IEnumerable<object[]> GetEventByIdDataSource { get; } = new[]
            {
                new object[]
                {
                    new Concert
                    {
                        Id = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f55"),
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
                                Event_Id = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f55"),
                                Created_At = DateTime.Now,
                             },
                        },
                    },

                    new ResponseConcertJson
                    {
                        Id = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f55"),
                        Title = "Event-test",
                        Details = "Test",
                        MaximumAttendees = 10,
                        AttendeesAmount = 1,
                    }
                },
            };
        }
    }
}

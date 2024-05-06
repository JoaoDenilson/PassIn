using Microsoft.Extensions.Logging;
using PassIn.Communication.Responses;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTest.Service
{
    public static class MockedObjects
    {
        public static Dictionary<string, Concert> concertObjs = new Dictionary<string, Concert>()
        {
            {
                "concert-01", new Concert
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
                }
            }
        };
        public static Dictionary<string, ResponseConcertJson> responseConcert = new Dictionary<string, ResponseConcertJson>()
        {
            {
                "responserConcert-01", new ResponseConcertJson
                {
                    Id = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f55"),
                    Title = "Event-test",
                    Details = "Test",
                    MaximumAttendees = 10,
                    AttendeesAmount = 1,
                }
            }
        };
    }
}

using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Service
{
    public sealed partial class RegisterConcertTest
    {
        private static class DataSources
        {
            public static IEnumerable<Object[]> RegisterConcertDataSource { get; } = new[]
            {
                new object[]
                {
                    new Concert
                    {
                        Id = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f66"),
                        Title = "Title of Concert",
                        Details = "Title Test",
                        Slug = "title Test",
                        Maximum_Attendees = 10
                    },

                    new RequestConcertJson
                    {
                        Title = "Title of Concert",
                        Details = "Title Test",
                        MaximumAttendees = 10
                    },

                    new ResponseRegisteredJson
                    {
                        Id = Guid.Parse("440cdeee-5b8a-462a-96fd-20b24bd82f66")
                    }
                },
            };
        }
    }
}

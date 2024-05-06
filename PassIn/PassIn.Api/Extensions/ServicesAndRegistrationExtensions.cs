using PassIn.Application.UseCases.Attendees.GetAllByEventId;
using PassIn.Application.UseCases.Attendees.RegisterAttendee;
using PassIn.Application.UseCases.Checkings.DoCheckin;
using PassIn.Application.UseCases.Checkins.DoCheckin;
using PassIn.Application.UseCases.Events.GetById;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Repository;

namespace PassIn.Api.Extensions
{
    public static class ServicesAndRegistrationExtensions
    {
        public static IServiceCollection AddServicesAndRegistration(this IServiceCollection services)
        {
            _= services.AddTransient<IConcertRepository, ConcertRepository>();
            _ = services.AddTransient<IRegisterAttendeeOnConcertUseCase, RegisterAttendeeOnConcertUseCase>();
            _ = services.AddTransient<IGetConcertByIdUseCase, GetConcertByIdUseCase>();
            _ = services.AddTransient<IRegisterConcertUseCase, RegisterConcertUseCase>();

            _ = services.AddTransient<IAttendeeRepository, AttendeeRepository>();
            _ = services.AddTransient<IGetAllAttendeesByConcertIdUseCase, GetAllAttendeesByConcertIdUseCase>();

            _ = services.AddTransient<ICheckInRepository, CheckInRepository>();
            _ = services.AddTransient<IDoAttendeeCheckinUseCase, DoAttendeeCheckinUseCase>();

            return services;
        }
    }
}

using Microsoft.AspNetCore.Mvc.ApplicationParts;
using AppointmentSystem.Services;
using AppointmentSystem.Repositories;
using Moq;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace UnitTest.Service
{
    public class AppointmentServiceTest
    {
        
        public async void Create_WhenSlotNotAvailable_ShouldThrowException()
        {
            //Arrange
            var appointmentRepository = new Mock<IAppointmentRepository>();
            var slotRepository = new Mock<ISlotRepository>();
            var appointmentService = new AppointmentService(appointmentRepository.Object, slotRepository.Object);
            

        }
    }
}

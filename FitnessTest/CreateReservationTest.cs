using Moq;
using Xunit;
using FitnessBeheerDomain.Services;
using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Exceptions;
using System;
using System.Collections.Generic;
using FitnessBeheerDomain.Interfaces;

namespace FitnessBeheerDomain.Tests
{
    public class ReservationServiceTests
    {
        [Fact]
        public void AddReservation_ShouldThrowReservationException_WhenReservationIsInThePast()
        {
            var reservation = new Reservation
            {
                MemberId = 1,
                EquipmentId = 1,
                ReservationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                TimeSlots = new List<TimeSlot>
                {
                    new TimeSlot
                    {
                        StartTime = new TimeOnly(10, 0)
                    }
                }
            };

            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var reservationService = new ReservationService(reservationRepositoryMock.Object);

            var exception = Assert.Throws<ReservationException>(() => reservationService.AddReservation(reservation));
            Assert.Equal("The reservation must be in the future.", exception.Message);
        }

        [Fact]
        public void AddReservation_ShouldCallAddReservation_WhenValidReservation()
        {
            var reservation = new Reservation
            {
                MemberId = 1,
                EquipmentId = 1,
                ReservationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                TimeSlots = new List<TimeSlot>
                {
                    new TimeSlot
                    {
                        StartTime = new TimeOnly(10, 0)
                    }
                }
            };

            var reservationRepositoryMock = new Mock<IReservationRepository>();
            reservationRepositoryMock.Setup(r => r.GetReservationsByDateAndMember(It.IsAny<DateOnly>(), It.IsAny<int>()))
                .Returns(new List<Reservation>());

            var reservationService = new ReservationService(reservationRepositoryMock.Object);

            reservationService.AddReservation(reservation);

                reservationRepositoryMock.Verify(r => r.AddReservation(It.Is<Reservation>(res =>
                res.MemberId == reservation.MemberId &&
                res.EquipmentId == reservation.EquipmentId &&
                res.ReservationDate == reservation.ReservationDate &&
                res.TimeSlots.Count == reservation.TimeSlots.Count &&
                res.TimeSlots[0].StartTime == reservation.TimeSlots[0].StartTime
                )), Times.Once);

        }
    }
}

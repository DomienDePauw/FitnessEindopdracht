using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using FitnessREST.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessREST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly ReservationService _reservationService;

    public ReservationController(ReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost("AddReservation")]
    public IActionResult CreateReservation([FromBody] ReservationDTO reservationDto)
    {
        if (reservationDto == null)
        {
            return BadRequest("Reservation data is required.");
        }

        var reservation = new Reservation(
                                    id: 0,
                                    memberId: reservationDto.MemberId,
                                    equipmentId: reservationDto.EquipmentId,
                                    timeSlots: reservationDto.TimeSlots.Select(ts => new TimeSlot(
                                    id: ts.Id,
                                    startTime: ts.StartTime
                                    )).ToList(),
                                    reservationDate: reservationDto.ReservationDate);
        _reservationService.AddReservation(reservation);
        return Ok("Reservation successfully added.");
    }

    //[HttpDelete("DeleteReservation/{id}")]
    //public IActionResult DeleteReservation(int reservationId)
    //{
    //    var existingReservation = _reservationService.GetReservationById(reservationId);
    //    if (existingReservation == null)
    //    {
    //        return NotFound($"Reservation with ID {reservationId} not found.");
    //    }
    //    _reservationService.DeleteReservation(reservationId);
    //    return Ok("Reservation successfully deleted.");
    //}
}
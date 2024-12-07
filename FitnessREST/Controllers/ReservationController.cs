using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using FitnessREST.DTO;
using Microsoft.AspNetCore.Mvc;
using FitnessBeheerDomain.Exceptions;

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

    [HttpDelete("DeleteReservation/{id}")]
    public IActionResult DeleteReservation(int id)
    {
        _reservationService.DeleteReservation(id);
        return Ok("Reservation successfully deleted.");
    }

    [HttpPut("UpdateReservation/{id}")]
    public IActionResult UpdateReservation(int id, ReservationDTO reservationDto)
    {
        if (reservationDto == null)
        {
            return BadRequest("Reservation data is required.");
        }

        try
        {
            var existingReservation = _reservationService.GetReservationById(id);
            if (existingReservation == null)
            {
                return NotFound($"Reservation with ID {id} not found.");
            }

            existingReservation.MemberId = reservationDto.MemberId;
            existingReservation.EquipmentId = reservationDto.EquipmentId;
            existingReservation.TimeSlots = reservationDto.TimeSlots.Select(ts => new TimeSlot(
                id: ts.Id,
                startTime: ts.StartTime
            )).ToList();
            existingReservation.ReservationDate = reservationDto.ReservationDate;

            _reservationService.UpdateReservation(id ,existingReservation);
            return Ok("Reservation successfully updated.");
        }
        catch (ReservationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
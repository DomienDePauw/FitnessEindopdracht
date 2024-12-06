
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessREST.DTO;

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
    public IActionResult CreateReservation([FromBody] Reservation reservation)
    {
        if (reservation == null)
        {
            return BadRequest("Reservation data is required.");
        }
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
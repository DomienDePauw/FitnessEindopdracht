
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessREST.DTO;

namespace FitnessREST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CyclingSessionController : ControllerBase
{
    private readonly CyclingSessionService _cyclingSessionService;

    public CyclingSessionController(CyclingSessionService cyclingSession)
    {
        _cyclingSessionService = cyclingSession;
    }

    [HttpGet("GetCyclingSession/{id}")]
    public IActionResult GetCyclingSessionById(int id)
    {
        var cyclingSession = _cyclingSessionService.GetCyclingSessionById(id);
        if (cyclingSession == null)
        {
            return NotFound($"Cycling session with ID {id} not found.");
        }
        return Ok(cyclingSession);
    }
}

using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessREST.DTO;

namespace FitnessREST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RunningSessionController : ControllerBase
{
    private readonly RunningSessionService _runningSessionService;

    public RunningSessionController(RunningSessionService runningSession)
    {
        _runningSessionService = runningSession;
    }

    [HttpGet("GetRunningSession/{id}")]
    public IActionResult GetRunningSessionById(int id)
    {
        var existingRunningSession = _runningSessionService.GetRunningSessionById(id);
        if (existingRunningSession == null)
        {
            return NotFound($"Running session with ID {id} not found.");
        }

        var runningSession = new RunningSession
        {
            Id = existingRunningSession.Id,
            Date = existingRunningSession.Date,
            Duration = existingRunningSession.Duration,
            AvgSpeed = existingRunningSession.AvgSpeed,
            Details = existingRunningSession.Details.Select(d => new RunningSessionDetail
            {
                Id = d.Id,
                SequenceNumber = d.SequenceNumber,
                IntervalTime = d.IntervalTime,
                IntervalSpeed = d.IntervalSpeed
            }).ToList()
        };

        return Ok(runningSession);
    }

}
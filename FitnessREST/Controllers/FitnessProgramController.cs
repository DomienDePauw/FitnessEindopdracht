
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessREST.DTO;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitnessREST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FitnessProgramController : ControllerBase
{
    private readonly FitnessProgramService _fitnessProgramService;

    public FitnessProgramController(FitnessProgramService fitnessProgramService)
    {
        _fitnessProgramService = fitnessProgramService;
    }

    [HttpPost("AddFitnessProgram")]
    public IActionResult CreateFitnessProgram([FromBody] FitnessProgramDTO fitnessProgramDto)
    {
        if (fitnessProgramDto == null)
        {
            return BadRequest("Fitness program data is required.");
        }

        var fitnessProgram = new FitnessProgram(

            programCode: fitnessProgramDto.ProgramCode,
            name: fitnessProgramDto.Name,
            target: fitnessProgramDto.Target,
            startDate: fitnessProgramDto.StartDate,
            maxMembers: fitnessProgramDto.MaxMembers
        );
        _fitnessProgramService.AddFitnessProgram(fitnessProgram);
        return Ok("Fitness program successfully added.");
    }

    [HttpPut("UpdateFitnessProgram")]
    public IActionResult UpdateFitnessProgram(int id,[FromBody] FitnessProgramDTO fitnessProgramDto)
    {
        if (fitnessProgramDto == null)
        {
            return BadRequest("Fitness program data is required.");
        }

        var fitnessProgram = new FitnessProgram(
            programCode: 0,
            name: fitnessProgramDto.Name,
            target: fitnessProgramDto.Target,
            startDate: fitnessProgramDto.StartDate,
            maxMembers: fitnessProgramDto.MaxMembers
        );
        _fitnessProgramService.UpdateFitnessProgram(id,fitnessProgram);
        return Ok("Fitness program successfully updated.");
    }
}
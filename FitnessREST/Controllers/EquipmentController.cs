
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessREST.DTO;

namespace FitnessREST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentController : ControllerBase
{
    private readonly EquipmentService _equipmentService;

    public EquipmentController(EquipmentService equipmentService)
    {
        _equipmentService = equipmentService;
    }

    [HttpPost("AddEquipment")]
    public IActionResult CreateEquipment([FromBody] Equipment equipment)
    {
        if (equipment == null)
        {
            return BadRequest("Equipment data is required.");
        }
        _equipmentService.AddEquipment(equipment);
        return Ok("Equipment successfully added.");
    }
}
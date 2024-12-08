
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
    public IActionResult CreateEquipment([FromBody] EquipmentDTO equipmentDto)
    {
        if (equipmentDto == null)
        {
            return BadRequest("Equipment data is required.");
        }

        var equipment = new Equipment(
            id: 0,
            type: new EquipmentType
            {
                Id = equipmentDto.Type.Id,
                Name = equipmentDto.Type.Name,
                Description = equipmentDto.Type.Description
            }
        );

        _equipmentService.AddEquipment(equipment);

        return Ok("Equipment successfully added.");
    }

    [HttpPut("PutEquipmentInMaintenance/{id}")]
    public IActionResult PutEquipmentInMaintenance(int id, [FromBody] EquipmentMaintenanceDTO dto)
    {
        if (dto == null)
        {
            return BadRequest("Equipment data is required.");
        }

        try
        {
            var existingEquipment = _equipmentService.GetEquipmentById(id);
            if (existingEquipment == null)
            {
                return NotFound($"Equipment with ID {id} not found.");
            }

            existingEquipment.IsAvailable = dto.IsAvailable;

            _equipmentService.UpdateEquipment(id, existingEquipment);

            return Ok("Equipment successfully updated.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
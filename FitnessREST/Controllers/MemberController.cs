
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessREST.DTO;

namespace FitnessREST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly MemberService _memberService;

    public MemberController(MemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpPost("AddMember")]
    public IActionResult CreateMember([FromBody] MemberDTO memberDto)
    {
        if (memberDto == null)
        {
            return BadRequest("Member data is required.");
        }
        var member = new Member(
            id: 0,
            firstName: memberDto.FirstName,
            lastName: memberDto.LastName,
            email: memberDto.Email,
            city: memberDto.City,
            birthday: memberDto.Birthday,
            interests: memberDto.Interests ?? new List<string>(),
            memberType: memberDto.MemberType,
            fitnessPrograms: new List<FitnessProgram>(), 
            reservations: new List<Reservation>(),
            cyclingSessions: new List<CyclingSession>(),
            runningSessions: new List<RunningSession>()
        );
        _memberService.AddMember(member);
        return Ok("Member successfully added.");
    }
    [HttpPut("UpdateMember/{id}")]
    public IActionResult UpdateMember(int memberId, MemberDTO memberDto)
    {
        if (memberDto == null)
        {
            return BadRequest("Member data is required.");
        }

        try
        {
            var existingMember = _memberService.GetMemberById(memberId);
            if (existingMember == null)
            {
                return NotFound($"Member with ID {memberId} not found.");
            }

            existingMember.FirstName = memberDto.FirstName;
            existingMember.LastName = memberDto.LastName;
            existingMember.Email = memberDto.Email;
            existingMember.City = memberDto.City;
            existingMember.Birthday = memberDto.Birthday;
            existingMember.Interests = memberDto.Interests ?? new List<string>();
            existingMember.MemberType = memberDto.MemberType;
            _memberService.UpdateMember(memberId,existingMember);
            
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
    [HttpGet("GetMember/{id}")]
    public IActionResult GetMemberWithDetails(int id)
    {
        try
        {
            var member = _memberService.GetMemberWithDetails(id);
            return Ok(member);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
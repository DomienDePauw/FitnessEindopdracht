
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

    [HttpPost]
    public IActionResult CreateMember([FromBody] CreateMemberDTO memberDto)
    {
        if (memberDto == null)
        {
            return BadRequest("Member data is required.");
        }

        // Map DTO naar domeinmodel
        var member = new Member(
            id: 0, // Id wordt gegenereerd in de datalaag
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

        _memberService.AddMember(member); // Domeinmodel naar de service
        return Ok("Member successfully added.");
    }
    //[HttpPut]
    //public IActionResult UpdateMember(int memberId, Member member)
    //{
    //    try
    //    {
    //        _memberService.UpdateMember(memberId, member);
    //        return NoContent();
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}


}
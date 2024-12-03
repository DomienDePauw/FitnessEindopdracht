
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult CreateMember([FromBody] Member member)
    {
        if (member == null)
        {
            return BadRequest("Member cannot be null.");
        }

        _memberService.AddMember(member);
        return Ok(member);
    }

    //[HttpPut]
    //public IActionResult UpdateMember(int memberId, Member member) 
    //{
    //    try
    //    {
    //        _memberRepository.UpdateMember(memberId, member);
    //        return NoContent();
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}


}
using FitnessBL;
using FitnessDL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessREST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly MemberRepository _memberRepository;

    public MemberController(MemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    [HttpGet]
    public async Task<ActionResult <List<Member>>> Get() 
    {
        return await _memberRepository.GetAll();
    }

    //Id wordt meegegeven in de post en dat hoeft niet 
    [HttpPost]
    public IActionResult AddMember([FromBody] Member member)
    {
        if (member == null)
        {
            return BadRequest("Member cannot be null.");
        }

        _memberRepository.AddMember(member);
        return Ok(member);
    }


    [HttpPut]
    public IActionResult UpdateMember(int memberId, Member member) 
    {
        try
        {
            _memberRepository.UpdateMember(memberId, member);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
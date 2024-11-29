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
}
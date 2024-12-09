
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerDomain.Services;
using FitnessREST.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            var member = _memberService.GetMemberById(memberId);
            if (member == null)
            {
                return NotFound($"Member with ID {memberId} not found.");
            }

            member.FirstName = memberDto.FirstName;
            member.LastName = memberDto.LastName;
            member.Email = memberDto.Email;
            member.City = memberDto.City;
            member.Birthday = memberDto.Birthday;
            member.Interests = memberDto.Interests ?? new List<string>();
            member.MemberType = memberDto.MemberType;
            _memberService.UpdateMember(memberId, member);
            
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
            Member member = _memberService.GetMemberWithDetails(id);
            return Ok(member);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("GetSessionsOrderedByDate/{id}")]
    public SessionDTO GetSessions(int id, int month, int year)
    {
        Member member = _memberService.GetMemberWithSessions(id);
        SessionDTO sessionDTO = new SessionDTO();

        sessionDTO.cyclingSessions = member.CyclingSessions
            .Where(c => c.Date.Year == year && c.Date.Month == month)
            .OrderBy(c => c.Date)
            .ToList();

        sessionDTO.runningSessions = member.RunningSessions
            .Where(c => c.Date.Year == year && c.Date.Month == month)
            .OrderBy(r => r.Date)
            .ToList();

        return sessionDTO;
    }

    [HttpGet("AllMonthlySessionsOverview/{id}/{year}")]
    public List<AllSessionsOverviewDTO> GetMonthlyAllSessionsOverview(int id, int year)
    {
        Member member = _memberService.GetMemberWithSessions(id);

        var allSessions = member.CyclingSessions
            .Select(c => new { Date = c.Date })
            .Concat(member.RunningSessions.Select(r => new { Date = r.Date }));

        var totalSessions = allSessions
            .Where(s => s.Date.Year == year)
            .GroupBy(s => s.Date.Month)
            .ToDictionary(g => g.Key, g => g.Count());

        var result = Enumerable.Range(1, 12)
            .Select(month => new AllSessionsOverviewDTO
            {
                Month = month,
                TotalSessionCount = totalSessions.ContainsKey(month) ? totalSessions[month] : 0
            })
            .ToList();

        return result;
    }

    [HttpGet("StatisticSessionsOverview/{id}/{year}")]
    public StatisticSessionsDTO GetSessionsOverview(int id, int year)
    {
        Member member = _memberService.GetMemberWithSessions(id);

        var allSessions = member.CyclingSessions
            .Select(c => new { Date = c.Date, Duration = c.Duration })
            .Concat(member.RunningSessions.Select(r => new { Date = r.Date, Duration = r.Duration }));

        var filteredSessions = allSessions.Where(s => s.Date.Year == year).ToList();

        int totalSessions = filteredSessions.Count;

        double totalDuration = filteredSessions.Sum(s => s.Duration);
        var longestSession = filteredSessions.OrderByDescending(s => s.Duration).FirstOrDefault();
        var shortestSession = filteredSessions.OrderBy(s => s.Duration).FirstOrDefault();

        double averageDuration = totalSessions > 0 ? totalDuration / totalSessions : 0;

        double totalDurationInHours = totalDuration / 60;

        var result = new StatisticSessionsDTO
        {
            TotalSessionCount = totalSessions,
            TotalDurationInHours = totalDurationInHours,
            LongestSessionDuration = longestSession?.Duration ?? 0, 
            ShortestSessionDuration = shortestSession?.Duration ?? 0,
            AverageSessionDuration = averageDuration
        };

        return result;
    }

    [HttpGet("GetMonthlySessionOverview/{id}/{year}")]
    public List<SessionsOverviewDTO> GetMonthlySessionOverview(int id, int year)
    {
        Member member = _memberService.GetMemberWithSessions(id);

        var cyclingSessions = member.CyclingSessions
            .Where(c => c.Date.Year == year)
            .GroupBy(c => c.Date.Month)
            .ToDictionary(g => g.Key, g => g.Count());

        var runningSessions = member.RunningSessions
            .Where(r => r.Date.Year == year)
            .GroupBy(r => r.Date.Month)
            .ToDictionary(g => g.Key, g => g.Count());

        var result = Enumerable.Range(1, 12)
            .Select(month => new SessionsOverviewDTO
            {
                Month = month,
                CyclingSessionCount = cyclingSessions.GetValueOrDefault(month, 0),
                RunningSessionCount = runningSessions.GetValueOrDefault(month, 0)
            })
            .ToList();

        return result;
    }

    [HttpGet("GetMonthlySessionWithImpact/{id}/{month}/{year}")]
    public List<CyclingSessionDTO> GetMonthlySessionWithImpact(int id, int month, int year)
    {
        Member member = _memberService.GetMemberWithSessions(id);

        var cyclingSessions = member.CyclingSessions
            .Where(c => c.Date.Year == year && c.Date.Month == month)
            .Select(c => new CyclingSessionDTO
            {
                Id = c.Id,
                Date = c.Date,
                Duration = c.Duration,
                AvgWatt = c.AvgWatt,
                MaxWatt = c.MaxWatt,
                AvgCadence = c.AvgCadence,
                MaxCadence = c.MaxCadence,
                TrainingType = c.TrainingType,
                Impact = CalculateImpact(c.Duration, c.AvgWatt).ToString()
            })
            .ToList();

        return cyclingSessions;
    }

    private Impact CalculateImpact(double duration, double avgWatt)
    {
        if (avgWatt < 150)
        {
            if (duration <= 90)
            {
                return Impact.Low;
            }
            else
            {
                return Impact.Medium;
            }
        }
        else if (avgWatt <= 200)
        {
            return Impact.Medium;
        }
        else
        {
            return Impact.High;
        }
    }
}
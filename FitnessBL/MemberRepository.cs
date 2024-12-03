using FitnessDL;
using FitnessDL.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessBL;
public class MemberRepository
{
    private readonly FitnessContext _context;

    public MemberRepository(FitnessContext context)
    {
        _context = context;
    }

    //Task is awaitable als dit aan het lopen is kan je iets anders doen ondertussen.
    public Task<List<Member>> GetAll()
    {
        return _context.Members.ToListAsync(); //Return TolistAsync geeft mij een Taks => List van member
    }

    public void AddMember(Member member)
    {
        _context.Members.Add(member);
        _context.SaveChanges();
    }

    public void UpdateMember(int memberId, Member updatedMember) 
    {
       var member = _context.Members.FirstOrDefault(m => m.MemberId == memberId);

        if (member == null)
        {
            throw new Exception($"{memberId} member is niet gevonden.");
        }

        member.FirstName = updatedMember.FirstName;
        member.LastName = updatedMember.LastName;
        member.Email = updatedMember.Email;
        member.City = updatedMember.City;
        member.Birthday = updatedMember.Birthday;
        member.Interests = updatedMember.Interests;
        member.MemberType = updatedMember.MemberType;
        member.Reservations = updatedMember.Reservations;
        member.CyclingSessions = updatedMember.CyclingSessions;
        member.RunningSessions = updatedMember.RunningSessions;

        _context.SaveChanges();
    }
}

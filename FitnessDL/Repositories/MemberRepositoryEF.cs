using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Exceptions;
using FitnessBeheerEFlayer.Mappers;
using Microsoft.EntityFrameworkCore;

namespace FitnessBeheerEFlayer.Repositories;
public class MemberRepositoryEF : IMemberRepository
{
    private readonly FitnessContext _context;

    public MemberRepositoryEF(FitnessContext ctx)
    {
        _context = ctx;
    }
    public void AddMember(Member member)
    {
        var m = MapMember.MapToEF(member);
        _context.members.Add(m);
        _context.SaveChanges();
    }

    public Member GetMemberWithSessions(int memberId)
    {
        var m = _context.members
             .Include(m => m.CyclingSessions)
             .Include(m => m.RunningSessions)
             .FirstOrDefault(m => m.Id == memberId);

        return MapMember.MapToDomain(m);
    }

    public Member GetMemberById(int Id)
    {
        var m = _context.members.FirstOrDefault(m => m.Id == Id);
        if (m == null)
        {
            throw new MemberRepositoryException($"{Id} member is niet gevonden.");
        }
        return MapMember.MapToDomain(m);
    }
    public void UpdateMember(int id, Member updatedMember)
    {
        var m = _context.members.FirstOrDefault(m => m.Id == id);

        if (m == null)
        {
            throw new MemberRepositoryException($"{id} member is niet gevonden.");
        }

        m.FirstName = updatedMember.FirstName;
        m.LastName = updatedMember.LastName;
        m.Email = updatedMember.Email;
        m.City = updatedMember.City;
        m.Birthday = updatedMember.Birthday;
        m.Interests = updatedMember.Interests;
        m.MemberType = updatedMember.MemberType.ToString();

        _context.SaveChanges();
    }

    public Member GetMemberWithDetails(int id)
    {
        var m = _context.members
            .Include(m => m.Reservations)
            .Include(m => m.FitnessPrograms)
            .Include(m => m.CyclingSessions)
            .Include(m => m.RunningSessions)
            .FirstOrDefault(m => m.Id == id);

        if (m == null)
        {
            throw new Exception("Member not found.");
        }

        return MapMember.MapToDomain(m);
    }
}

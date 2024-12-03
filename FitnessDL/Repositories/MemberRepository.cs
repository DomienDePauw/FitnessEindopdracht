using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Mappers;
using FitnessBeheerEFlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Repositories;
public class MemberRepositoryEF : IMemberRepository
{
    private readonly FitnessContext _context;

    public MemberRepositoryEF(FitnessContext ctx)
    {
        _context = ctx;
    }
    //Task is awaitable als dit aan het lopen is kan je iets anders doen ondertussen.
    //public Task<List<Member>> GetAll()
    //{
    //    return _context.members.ToListAsync(); //Return TolistAsync geeft mij een Taks => List van member
    //}

    public void AddMember(Member member)
    {
        var memberEF = MapMember.MapToEF(member);
        _context.members.Add(memberEF);
        _context.SaveChanges();
    }

    //public void UpdateMember(int memberId, Member updatedMember)
    //{
    //    var member = _context.members.FirstOrDefault(m => m.MemberId == memberId);

    //    if (member == null)
    //    {
    //        throw new Exception($"{memberId} member is niet gevonden.");
    //    }

    //    member.FirstName = updatedMember.FirstName;
    //    member.LastName = updatedMember.LastName;
    //    member.Email = updatedMember.Email;
    //    member.City = updatedMember.City;
    //    member.Birthday = updatedMember.Birthday;
    //    member.Interests = updatedMember.Interests;
    //    member.MemberType = updatedMember.MemberType;
    //    member.Reservations = updatedMember.Reservations;
    //    member.CyclingSessions = updatedMember.CyclingSessions;
    //    member.RunningSessions = updatedMember.RunningSessions;

    //    _context.SaveChanges();
    //}
}

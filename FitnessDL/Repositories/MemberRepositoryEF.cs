using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Mappers;
using FitnessBeheerEFlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerEFlayer.Model;
using Microsoft.EntityFrameworkCore;
using FitnessBeheerEFlayer.Exceptions;

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
    public Member GetMemberById (int Id)
    {
        var memberEF = _context.members.FirstOrDefault(m => m.Id == Id);
        if (memberEF == null)
        {
            throw new MemberRepositoryException($"{Id} member is niet gevonden.");
        }
        return MapMember.MapToDomain(memberEF);
    }
    public void UpdateMember(int id, Member updatedMember)
    {
        var existingEFMember = _context.members.FirstOrDefault(m => m.Id == id);

        if (existingEFMember == null)
        {
            throw new MemberRepositoryException($"{id} member is niet gevonden.");
        }

        existingEFMember.FirstName = updatedMember.FirstName;
        existingEFMember.LastName = updatedMember.LastName;
        existingEFMember.Email = updatedMember.Email;
        existingEFMember.City = updatedMember.City;
        existingEFMember.Birthday = updatedMember.Birthday;
        existingEFMember.Interests = updatedMember.Interests;
        existingEFMember.MemberType = updatedMember.MemberType.ToString();

        _context.SaveChanges();
    }
}

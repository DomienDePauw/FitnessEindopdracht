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
}

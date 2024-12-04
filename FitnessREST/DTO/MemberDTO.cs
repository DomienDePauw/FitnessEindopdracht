using FitnessBeheerDomain.Model;

namespace FitnessREST.DTO;
public class CreateMemberDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public DateTime Birthday { get; set; }
    public List<string>? Interests { get; set; }
    public MemberType MemberType { get; set; }
}


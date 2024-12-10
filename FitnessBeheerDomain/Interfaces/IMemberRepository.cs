using FitnessBeheerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Interfaces;
public interface IMemberRepository
{
    void AddMember(Member member);
    Member GetMemberById(int memberId);
    Member GetMemberWithDetails(int id);
    void UpdateMember(int memberId, Member updatedMember);
    Member GetMemberWithSessions(int memberId);
    List<Member> GetAllMembers();
}

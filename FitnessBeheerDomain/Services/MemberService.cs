using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Services;
public class MemberService
{
    private readonly IMemberRepository _repository;

    public MemberService(IMemberRepository repository)
    {
        this._repository = repository;
    }

    public void AddMember(Member member)
    {
        _repository.AddMember(member);
    }

    public Member GetMemberById(int memberId)
    {
        return _repository.GetMemberById(memberId);
    }

    public void UpdateMember(int memberId, Member member)
    {
        _repository.UpdateMember(memberId, member);
    }
}

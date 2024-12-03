using FitnessBeheerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Interfaces;
public interface IMemberRepository
{
    public void AddMember(Member member);
}

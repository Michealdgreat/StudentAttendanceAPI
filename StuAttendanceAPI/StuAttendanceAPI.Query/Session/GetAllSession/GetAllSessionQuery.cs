using Common.Query;
using StuAttendanceAPI.Domain.SessionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Session.GetAllSession
{
    public record class GetAllSessionQuery : IQuery<List<SessionDto>?>;
}

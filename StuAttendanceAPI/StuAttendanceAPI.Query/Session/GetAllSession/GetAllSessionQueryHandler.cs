using Common.Query;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.SessionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Session.GetAllSession
{
    public class GetAllSessionQueryHandler(ISessionRepository sessionRepository) : IQueryHandler<GetAllSessionQuery, List<SessionDto>?>
    {
        private readonly ISessionRepository _sessionRepository = sessionRepository;

        public async Task<List<SessionDto>?> Handle(GetAllSessionQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var result = await _sessionRepository.LoadData<SessionDto, dynamic>(StuAttSqlFactory.GetAllSessionsFunctionQuery(), new { });

                return result;
            }
            catch (Exception)
            {

                return default;
            }
        }
    }
}

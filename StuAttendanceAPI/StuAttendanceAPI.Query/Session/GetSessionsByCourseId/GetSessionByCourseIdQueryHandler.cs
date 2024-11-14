using Common.Query;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.SessionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Session.GetSessionsByCourseId
{
    public class GetSessionByCourseIdQueryHandler(ISessionRepository sessionRepository) : IQueryHandler<GetSessionByCourseIdQuery, List<SessionDto>?>
    {
        private readonly ISessionRepository _sessionRepository = sessionRepository;

        public async Task<List<SessionDto>?> Handle(GetSessionByCourseIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var (SessionQUery, SessionPara) = StuAttSqlFactory.GetSessionsForCourseQuery(request.CourseId);

                var result = await _sessionRepository.LoadData<SessionDto, dynamic>(SessionQUery, SessionPara);

                return result;
            }
            catch (Exception)
            {

                return default;
            }
        }
    }
}

using Common.Query;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.SessionAggregate;
using StuAttendanceAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Session.GetSessionById
{
    public class GetSessionByIdQueryHandler(ISessionRepository sessionRepository) : IQueryHandler<GetSessionByIdQuery, SessionDto?>
    {
        private readonly ISessionRepository _sessionRepository = sessionRepository;

        public async Task<SessionDto?> Handle(GetSessionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var (sesQuery, sessPara) = StuAttSqlFactory.GetSessionDetailsByIdQuery(request.SessionId);

                var result = await _sessionRepository.LoadOneData<SessionDto, dynamic>(sesQuery, sessPara);

                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

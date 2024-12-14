using Common.Application;
using StuAttendanceAPI.Domain.RoleAggregate;
using StuAttendanceAPI.Domain.SessionAggregate;
using System;
using System.Linq;
using System.Xml.Linq;
using static StuAttendanceAPI.Domain.SessionAggregate.Session;

namespace StuAttendanceAPI.Application.Session.Create
{
    public class CreateSessionCommandHandler(ISessionRepository sessionRepository) : IBaseCommandHandler<CreateSessionCommand>
    {
        private readonly ISessionRepository _sessionRepository = sessionRepository;

        public async Task<OperationResult> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.CommandSender!.Role != Role.Teacher.ToString())
                {
                    return OperationResult.Error();
                }

                var session = SessionFactory.CreateNew(request.CourseId, request.Date, request.StartAt, request.EndAt, request.Name!);

                await _sessionRepository.SaveData<dynamic>("insert_session", new
                {
                    session_id = session.SessionId,
                    course_id = session.CourseId,
                    session_date = session.Date,
                    start_at = session.StartAt,
                    end_at = session.EndAt,
                    name = session.Name,
                    total_duration = session.TotalDuration
                });

                return OperationResult.Success();
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }
    }
}

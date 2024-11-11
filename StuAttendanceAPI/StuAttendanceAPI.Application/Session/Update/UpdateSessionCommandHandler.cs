using Common.Application;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.RoleAggregate;
using StuAttendanceAPI.Domain.SessionAggregate;
using System;
using System.Linq;
using static StuAttendanceAPI.Domain.SessionAggregate.Session;

namespace StuAttendanceAPI.Application.Session.Update
{
    public class UpdateSessionCommandHandler(ISessionRepository sessionRepository) : IBaseCommandHandler<UpdateSessionCommand>
    {
        private readonly ISessionRepository _sessionRepository = sessionRepository;

        public async Task<OperationResult> Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.CommandSender!.Role != Role.Teacher.ToString() || request.CommandSender.Role != Role.Admin.ToString())
                {
                    return OperationResult.Error();
                }

                var (sesQuery, sessPara) = StuAttSqlFactory.GetSessionDetailsByIdQuery(request.SessionId);

                var result = await _sessionRepository.LoadOneData<SessionDto, dynamic>(sesQuery, sessPara);

                if (result == null || result.TeacherId != request.CommandSender.UserId)
                {
                    return OperationResult.Error("NOT ALLOWED");

                }

                var session = SessionFactory.UpdateExisting(request.SessionId, request.CourseId, request.Date, request.StartAt, request.EndAt, request.Name!);

                await _sessionRepository.SaveData<dynamic>("update_session", new
                {
                    session_id = session.SessionId,
                    course_id = session.CourseId,
                    date = session.Date,
                    start_at = session.StartAt,
                    end_at = session.EndAt,
                    name = session.Name,
                    total_duration = session.TotalDuration,
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

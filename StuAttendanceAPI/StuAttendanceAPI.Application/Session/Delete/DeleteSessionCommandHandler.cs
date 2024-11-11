using Common.Application;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.RoleAggregate;
using StuAttendanceAPI.Domain.SessionAggregate;
using System;
using System.Linq;
using static StuAttendanceAPI.Domain.SessionAggregate.Session;

namespace StuAttendanceAPI.Application.Session.Delete
{
    public class DeleteSessionCommandHandler(ISessionRepository sessionRepository) : IBaseCommandHandler<DeleteSessionCommand>
    {
        private readonly ISessionRepository _sessionRepository = sessionRepository;

        public async Task<OperationResult> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.CommandSender!.Role != Role.Teacher.ToString() || request.CommandSender.Role != Role.Admin.ToString())
                {
                    return OperationResult.Error();
                }

                var (sesQuery, sessPara) = StuAttSqlFactory.GetSessionDetailsByIdQuery(request.SessionId);

                var result = await _sessionRepository.LoadOneData<SessionDto, dynamic>(sesQuery, sessPara);

                if (result == null || result.TeacherId!=request.CommandSender.UserId)
                {
                    return OperationResult.Error("NOT ALLOWED");

                }

                await _sessionRepository.DeleteData<dynamic>("delete_session", new
                {
                    sid = request.SessionId
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

using Common.Query;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.UserAggregate;
using StuAttendanceAPI.Query.User.DTO;
using StuAttendanceAPI.Query.User.GetById;

namespace StuAttendanceAPI.Query.User.GetById
{
    /// <summary>
    /// Get user by id query handler.
    /// returns user dto
    /// </summary>
    public class GetUserByIdQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var (ByIdQuery, Parameter) = StuAttSqlFactory.GetUserByIdQuery(request.UserId);



            var result = await _userRepository.LoadOneData<UserDTO, dynamic>(ByIdQuery, Parameter);

            return result!;

        }
    }
}
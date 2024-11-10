using Common.Query;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.UserAggregate;
using StuAttendanceAPI.Query.User.DTO;
using StuAttendanceAPI.Query.User.GetList;

namespace Query.User.GetList
{
    /// <summary>
    /// returns list of users registered on the platform.
    /// </summary>
    public class GetUserListQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserListQuery, List<UserDTO>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<List<UserDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            //var (GetAllUsersQuery, Parameter) = StuAttSqlFactory.GetAllUsers();

            //  var result = await _userRepository.LoadData<UserDTO, dynamic>(GetAllUsersQuery, Parameter);


            //return result;

            throw new NotImplementedException();
        }
    }
}
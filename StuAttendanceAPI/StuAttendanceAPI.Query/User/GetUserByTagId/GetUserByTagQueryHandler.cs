using Application.User.Services;
using Common.Query;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.UserAggregate;
using StuAttendanceAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.User.GetUserByTagId
{
    public class GetUserByTagQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserByTagQuery, UserDtoForClaims?>
    {
        private readonly IUserRepository _repository = userRepository;

        public async Task<UserDtoForClaims?> Handle(GetUserByTagQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var (emailQuery, emailParameter) = StuAttSqlFactory.GetUserByPasswordQuery(request.hashedTag);
                var result = await _repository.LoadOneData<UserDtoForClaims, dynamic>(emailQuery, emailParameter);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

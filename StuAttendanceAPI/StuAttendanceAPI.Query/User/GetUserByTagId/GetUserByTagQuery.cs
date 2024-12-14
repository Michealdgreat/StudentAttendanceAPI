using Application.User.Services;
using Common.Query;
using StuAttendanceAPI.Query.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.User.GetUserByTagId
{
    public record GetUserByTagQuery(string hashedTag) : IQuery<UserDtoForClaims?>;
}

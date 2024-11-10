using Common.Application;
using MediatR;
using StuAttendanceAPI.Application.Course.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Application.Course.Update
{
    public class UpdateCourseCommandHandler : IBaseCommandHandler<UpdateCourseCommand>
    {
        public Task<OperationResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Application.Course.Create
{
    public class CreateCourseCommandHandler : IBaseCommandHandler<CreateCourseCommand>
    {
        public Task<OperationResult> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

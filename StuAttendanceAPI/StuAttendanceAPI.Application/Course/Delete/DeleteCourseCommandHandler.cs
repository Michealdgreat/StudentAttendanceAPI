using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Application.Course.Delete
{
    public class DeleteCourseCommandHandler : IBaseCommandHandler<DeleteCourseCommand>
    {
        public Task<OperationResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

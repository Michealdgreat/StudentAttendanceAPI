using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Application.Session.Delete
{
    public class DeleteSessionCommandHandler : IBaseCommandHandler<DeleteSessionCommand>
    {
        public Task<OperationResult> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

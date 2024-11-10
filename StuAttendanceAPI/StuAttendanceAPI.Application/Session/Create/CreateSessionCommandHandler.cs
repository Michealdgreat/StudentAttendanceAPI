using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Application.Session.Create
{
    public class CreateSessionCommandHandler : IBaseCommandHandler<CreateSessionCommand>
    {
        public Task<OperationResult> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

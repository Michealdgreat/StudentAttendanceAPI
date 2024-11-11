using Common.Application;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.Session.Update
{
    public class UpdateSessionCommandHandler : IBaseCommandHandler<UpdateSessionCommand>
    {
        public Task<OperationResult> Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

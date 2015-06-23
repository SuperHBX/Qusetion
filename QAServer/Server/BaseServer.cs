using QADAL.EntityFrameWorkCore.UnitOfWorkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAServer.Server
{
    public class BaseServer
    {
        protected IUnitOfWork IUnitOfWork { get; private set; }

        public BaseServer(IUnitOfWork _iUnitOfWork)
        {
            IUnitOfWork = _iUnitOfWork;
        }
    }
}

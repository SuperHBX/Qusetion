using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADAL.EntityFrameWorkCore.Content
{
    public class LogRepoistory:DbContextRepository<Models.Log>
    {
        public LogRepoistory(UnitOfWorkCore.IUnitOfWork db)
            : base((QuestionContext)db)
        {

        }
    }
}

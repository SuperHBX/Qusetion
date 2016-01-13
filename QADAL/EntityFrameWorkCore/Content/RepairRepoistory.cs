using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADAL.EntityFrameWorkCore.Content
{
    public class RepairRepoistory: DbContextRepository<Models.Repair>
    {
        public RepairRepoistory(UnitOfWorkCore.IUnitOfWork db)
         :base((QuestionContext)db)
        { }
    }
}

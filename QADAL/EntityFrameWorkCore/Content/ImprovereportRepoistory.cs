using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADAL.EntityFrameWorkCore.Content
{
    public class ImprovereportRepoistory:DbContextRepository<Models.Improvereport>
    {
        public ImprovereportRepoistory(UnitOfWorkCore.IUnitOfWork db)
            :base((QuestionContext)db)
        { }
    }
}

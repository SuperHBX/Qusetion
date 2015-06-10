using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADAL.EntityFrameWorkCore.Content
{
    public class CollectRepoistory:DbContextRepository<Models.Collect>
    {
        public CollectRepoistory(UnitOfWorkCore.IUnitOfWork db)
         :base((QuestionContext)db)
        { }
    }
}

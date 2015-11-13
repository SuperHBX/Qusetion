using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADAL.EntityFrameWorkCore.Content
{
    public class SelectOptionRepoistory:DbContextRepository<Models.Select_Option>
    {
        public SelectOptionRepoistory(UnitOfWorkCore.IUnitOfWork db)
         :base((QuestionContext)db)
        { }
    }
}

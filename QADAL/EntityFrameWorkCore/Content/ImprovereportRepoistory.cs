using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADAL.EntityFrameWorkCore.Content
{
    public class ImproveReportRepoistory:DbContextRepository<Models.ImproveReport>
    {
        public ImproveReportRepoistory(UnitOfWorkCore.IUnitOfWork db)
            :base((QuestionContext)db)
        { }
    }
}

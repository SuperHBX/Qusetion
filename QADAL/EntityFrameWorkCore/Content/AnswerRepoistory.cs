using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADAL.EntityFrameWorkCore.Content
{
    public class AnswerRepoistory:DbContextRepository<Models.Answer>
    {
        public AnswerRepoistory(UnitOfWorkCore.IUnitOfWork db)
            :base((QuestionContext)db)
        { }
    }
}

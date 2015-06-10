using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADAL.EntityFrameWorkCore.Content
{
    public class QuestionRepoistory:DbContextRepository<Models.Question>
    {
        public QuestionRepoistory(UnitOfWorkCore.IUnitOfWork db) 
            :base((QuestionContext)db)
        { }
    }
}

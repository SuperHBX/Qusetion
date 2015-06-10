using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADAL.EntityFrameWorkCore.Content
{
    public class TypeRepoistory:DbContextRepository<Models.Type>      
    {
        public TypeRepoistory(UnitOfWorkCore.IUnitOfWork db) 
            :base((QuestionContext)db)
        { }
    }
}

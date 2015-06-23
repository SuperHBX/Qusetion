using QADAL.EntityFrameWorkCore;
using QADAL.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAServer.Server
{
    class AnswerServer:BaseServer,IBaseServer<Answer>
    {
        public AnswerServer() : base(new QuestionContext()) { }



        public Answer Add(Answer entity)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<Answer> entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(params object[] id)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Answer> entity)
        {
            throw new NotImplementedException();
        }

        public void UpDate(Answer entity)
        {
            throw new NotImplementedException();
        }

        public void UpDate(IEnumerable<Answer> entity)
        {
            throw new NotImplementedException();
        }

        public Answer FindModel(params object[] arr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> FindModelList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> FindModelList(System.Linq.Expressions.Expression<Func<Answer, bool>> func)
        {
            throw new NotImplementedException();
        }




        public IEnumerable<Answer> FindModelList(System.Linq.Expressions.Expression<Func<Answer, bool>> func = null, Func<IQueryable<Answer>, IOrderedQueryable<Answer>> order = null, int pagesize = 10, int index = 1)
        {
            throw new NotImplementedException();
        }
    }
}

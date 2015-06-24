using QADAL.EntityFrameWorkCore;
using QADAL.EntityFrameWorkCore.Content;
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
        private AnswerRepoistory answerrepoistory;
        public AnswerServer() 
            : base(new QuestionContext())
        {
            answerrepoistory = new AnswerRepoistory(IUnitOfWork);
        }

        public Answer Add(Answer entity)
        {
            return answerrepoistory.Insert(entity);
        }

        public void Add(IEnumerable<Answer> entity)
        {
             answerrepoistory.Insert(entity);
        }

        public void Delete(params object[] id)
        {
            var temp=answerrepoistory.Find(id);
            answerrepoistory.Delete(temp);
        }

        public void Delete(IEnumerable<Answer> entity)
        {
            answerrepoistory.Delete(entity);
        }

        public void UpDate(Answer entity)
        {
            answerrepoistory.Update(entity);
        }

        public void UpDate(IEnumerable<Answer> entity)
        {
            answerrepoistory.Update(entity);
        }

        public Answer FindModel(params object[] arr)
        {
            return answerrepoistory.Find(arr);

        }

        public IEnumerable<Answer> FindModelList()
        {
            return answerrepoistory.GetModelList();
        }

        public IEnumerable<Answer> FindModelList(System.Linq.Expressions.Expression<Func<Answer, bool>> func)
        {
            return answerrepoistory.GetModelList(func);
        }




        public IEnumerable<Answer> FindModelList(System.Linq.Expressions.Expression<Func<Answer, bool>> func = null, Func<IQueryable<Answer>, IOrderedQueryable<Answer>> order = null, int pagesize = 10, int index = 1)
        {
            return answerrepoistory.GetModelList(func, order, pagesize, index);
        }
    }
}

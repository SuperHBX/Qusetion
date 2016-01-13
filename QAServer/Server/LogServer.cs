using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QADAL.Models;
using QADAL.EntityFrameWorkCore.Content;
using QADAL.EntityFrameWorkCore;

namespace QAServer.Server
{
    public class LogServer : BaseServer, IBaseServer<Log>
    {
        private LogRepoistory logrepoistory;
        public LogServer() 
            : base(new QuestionContext())
        {
            logrepoistory = new LogRepoistory(IUnitOfWork);
        }
        public void Add(IEnumerable<Log> entity)
        {
            logrepoistory.Insert(entity);
        }

        public Log Add(Log entity)
        {
            return logrepoistory.Insert(entity);
        }

        public void Delete(IEnumerable<Log> entity)
        {
            logrepoistory.Insert(entity);
        }

        public void Delete(Expression<Func<Log, bool>> func)
        {
            logrepoistory.Delete(func);
        }

        public void Delete(params object[] id)
        {
            var temp = FindModel(id);
            logrepoistory.Delete(temp);
        }

        public Log FindModel(params object[] arr)
        {
            return logrepoistory.Find(arr);
        }

        public IEnumerable<Log> FindModelList()
        {
            return logrepoistory.GetModelList();
        }

        public IEnumerable<Log> FindModelList(Expression<Func<Log, bool>> func)
        {
            return logrepoistory.GetModelList(func);
        }

        public void UpDate(IEnumerable<Log> entity)
        {
            logrepoistory.Update(entity);
        }

        public void UpDate(Log entity)
        {
            logrepoistory.Update(entity);
        }
    }
}

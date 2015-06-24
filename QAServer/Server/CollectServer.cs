using QADAL.EntityFrameWorkCore;
using QADAL.EntityFrameWorkCore.Content;
using QADAL.EntityFrameWorkCore.Models;
using QADAL.EntityFrameWorkCore.UnitOfWorkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAServer.Server
{
    public class CollectServer:BaseServer, IBaseServer<Collect>
    {
         CollectRepoistory collectrepoistory;
         public CollectServer() 
            : base(new QuestionContext()) 
        {
            collectrepoistory = new CollectRepoistory(IUnitOfWork);        
        }


        public Collect Add(Collect entity)
        {
            return collectrepoistory.Insert(entity);
        }

        public void Add(IEnumerable<Collect> entity)
        {
            collectrepoistory.Insert(entity);
        }

        public void Delete(params object[] id)
        {
            var temp=collectrepoistory.Find(id);
            collectrepoistory.Delete(temp);
        }

        public void Delete(IEnumerable<Collect> entity)
        {
            collectrepoistory.Delete(entity);
        }

        public void UpDate(Collect entity)
        {
            collectrepoistory.Update(entity);
        }

        public void UpDate(IEnumerable<Collect> entity)
        {
            collectrepoistory.Update(entity);
        }

        public Collect FindModel(params object[] arr)
        {
            return collectrepoistory.Find(arr);
        }

        public IEnumerable<Collect> FindModelList()
        {
            return collectrepoistory.GetModelList();
        }

        public IEnumerable<Collect> FindModelList(System.Linq.Expressions.Expression<Func<Collect, bool>> func)
        {
            return collectrepoistory.GetModelList(func);
        }

        public IEnumerable<Collect> FindModelList(System.Linq.Expressions.Expression<Func<Collect, bool>> func = null, Func<IQueryable<Collect>, IOrderedQueryable<Collect>> order = null, int pagesize = 10, int index = 1)
        {
            return collectrepoistory.GetModelList(func, order, pagesize, index);
        }


        public void Delete(System.Linq.Expressions.Expression<Func<Collect, bool>> func)
        {
            collectrepoistory.Delete(func);
        }
    }
}

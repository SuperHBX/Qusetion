using QADAL.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAServer.Server
{
    class CollectServer:IBaseServer<Collect>
    {

        public Collect Add(Collect entity)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<Collect> entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(params object[] id)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Collect> entity)
        {
            throw new NotImplementedException();
        }

        public void UpDate(Collect entity)
        {
            throw new NotImplementedException();
        }

        public void UpDate(IEnumerable<Collect> entity)
        {
            throw new NotImplementedException();
        }

        public Collect FindModel(params object[] arr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collect> FindModelList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collect> FindModelList(System.Linq.Expressions.Expression<Func<Collect, bool>> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collect> FindModelList(System.Linq.Expressions.Expression<Func<Collect, bool>> func = null, Func<IQueryable<Collect>, IOrderedQueryable<Collect>> order = null, int pagesize = 10, int index = 1)
        {
            throw new NotImplementedException();
        }
    }
}

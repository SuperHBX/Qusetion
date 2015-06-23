using QADAL.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QAServer.Server
{
    public interface IBaseServer<T> where T:Modelbase
    {
         T Add(T entity);
         void Add(IEnumerable<T> entity);
         void Delete(params object[] id);
         void Delete(IEnumerable<T> entity);
         void UpDate(T entity);
         void UpDate(IEnumerable<T> entity);
         T FindModel(params object[] arr);
         IEnumerable<T> FindModelList();
         IEnumerable<T> FindModelList(Expression<Func<T,bool>> func);
         IEnumerable<T> FindModelList(Expression<Func<T, bool>> func = null, Func<IQueryable<T>, IOrderedQueryable<T>> order = null, int pagesize = 10, int index = 1);

 
    }
}

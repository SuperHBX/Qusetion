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
    public class ImproveReportServer : BaseServer, IBaseServer<ImproveReport>
    {

        ImproveReportRepoistory improverepoistory;
        public ImproveReportServer() 
            : base(new QuestionContext()) 
        {
            improverepoistory = new ImproveReportRepoistory(IUnitOfWork);        
        }

        public ImproveReport Add(ImproveReport entity)
        {
            return improverepoistory.Insert(entity);
        }

        public void Add(IEnumerable<ImproveReport> entity)
        {
            improverepoistory.Insert(entity);
        }

        public void Delete(params object[] id)
        {
            var temp = improverepoistory.Find(id);
            improverepoistory.Delete(temp);
        }

        public void Delete(IEnumerable<ImproveReport> entity)
        {
            improverepoistory.Delete(entity);
        }

        public void UpDate(ImproveReport entity)
        {
            improverepoistory.Update(entity);
        }

        public void UpDate(IEnumerable<ImproveReport> entity)
        {
            improverepoistory.Update(entity);
        }

        public ImproveReport FindModel(params object[] arr)
        {
            return improverepoistory.Find(arr);
        }

        public IEnumerable<ImproveReport> FindModelList()
        {
            return improverepoistory.GetModelList();
        }

        public IEnumerable<ImproveReport> FindModelList(System.Linq.Expressions.Expression<Func<ImproveReport, bool>> func)
        {
            return improverepoistory.GetModelList(func);
        }

        public IEnumerable<ImproveReport> FindModelList(System.Linq.Expressions.Expression<Func<ImproveReport, bool>> func = null, Func<IQueryable<ImproveReport>, IOrderedQueryable<ImproveReport>> order = null, int pagesize = 10, int index = 1)
        {
            return improverepoistory.GetModelList(func, order, pagesize, index);
        }


        public void Delete(System.Linq.Expressions.Expression<Func<ImproveReport, bool>> func)
        {
            improverepoistory.Delete(func);
        }
    }
}

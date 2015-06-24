using QADAL.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAServer.Server
{
    class ImproveReportServer:IBaseServer<ImproveReport>
    {

        public ImproveReport Add(ImproveReport entity)
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<ImproveReport> entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(params object[] id)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<ImproveReport> entity)
        {
            throw new NotImplementedException();
        }

        public void UpDate(ImproveReport entity)
        {
            throw new NotImplementedException();
        }

        public void UpDate(IEnumerable<ImproveReport> entity)
        {
            throw new NotImplementedException();
        }

        public ImproveReport FindModel(params object[] arr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImproveReport> FindModelList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImproveReport> FindModelList(System.Linq.Expressions.Expression<Func<ImproveReport, bool>> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImproveReport> FindModelList(System.Linq.Expressions.Expression<Func<ImproveReport, bool>> func = null, Func<IQueryable<ImproveReport>, IOrderedQueryable<ImproveReport>> order = null, int pagesize = 10, int index = 1)
        {
            throw new NotImplementedException();
        }
    }
}

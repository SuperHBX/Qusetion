using QADAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using QADAL.EntityFrameWorkCore.Content;
using QADAL.EntityFrameWorkCore;

namespace QAServer.Server
{
    public class RepairServer : BaseServer, IBaseServer<Repair>
    {
        private RepairRepoistory  repairrepoistory;
        public RepairServer() 
            : base(new QuestionContext())
        {
            repairrepoistory = new RepairRepoistory(IUnitOfWork);
        }
        public void Add(IEnumerable<Repair> entity)
        {
            repairrepoistory.Insert(entity); 
        }

        public Repair Add(Repair entity)
        {
            return repairrepoistory.Insert(entity);
        }

        public void Delete(IEnumerable<Repair> entity)
        {
            repairrepoistory.Delete(entity);
        }

        public void Delete(Expression<Func<Repair, bool>> func)
        {
            repairrepoistory.Delete(func);
        }

        public void Delete(params object[] id)
        {
            var temp = FindModel(id);
            repairrepoistory.Delete(temp);
        }

        public Repair FindModel(params object[] arr)
        {

            return repairrepoistory.Find(arr);
        }

        public IEnumerable<Repair> FindModelList()
        {
            return repairrepoistory.GetModelList();
        }

        public IEnumerable<Repair> FindModelList(Expression<Func<Repair, bool>> func)
        {
            return repairrepoistory.GetModelList(func);
        }

        public void UpDate(IEnumerable<Repair> entity)
        {
            repairrepoistory.Update(entity);
        }

        public void UpDate(Repair entity)
        {
            repairrepoistory.Update(entity);
        }
    }
}

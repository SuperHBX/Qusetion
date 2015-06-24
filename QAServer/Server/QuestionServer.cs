using QADAL.EntityFrameWorkCore;
using QADAL.EntityFrameWorkCore.Content;
using QADAL.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QAServer.Server
{
    public class QuestionServer:BaseServer,IBaseServer<Question>
    {
        QuestionRepoistory questionrepoistory;
        public QuestionServer() 
            : base(new QuestionContext()) 
        {
            questionrepoistory = new QuestionRepoistory(IUnitOfWork);        
        }

        #region 作废
        //public Question Add(Question Q)
        //{
        //    return new QuestionRepoistory(IUnitOfWork).Insert(Q);
           
        //}

        //public void Delete(int id)
        //{
        //    var Q = new QuestionRepoistory(IUnitOfWork).Find(new int[] { id });
        //    new QuestionRepoistory(IUnitOfWork).Delete(Q);
        //}
       

        //public void Delete(Expression<Func<Question, bool>> func)
        //{
        //    var item = new QuestionRepoistory(IUnitOfWork).GetModelList(func);
        //    new QuestionRepoistory(IUnitOfWork).Delete(item);

        //}

        //public void UpDate(Question Q)
        //{
        //    new QuestionRepoistory(IUnitOfWork).Update(Q);
        //}

        // public void UpDate(Expression<Action<Question>> entity)
        //{
        //    new QuestionRepoistory(IUnitOfWork).Update(entity);
        //}

        // public Question FindModel(params object[] arrid) 
        // {
        //     return new QuestionRepoistory(IUnitOfWork).Find(arrid);
        // }

        // public IEnumerable<Question> FindModelList() 
        // {
        //     return new QuestionRepoistory(IUnitOfWork).GetModelList();
        // }

        // public IEnumerable<Question> FindModelList(Expression<Func<Question,bool>> func) 
        // {
        //     return new QuestionRepoistory(IUnitOfWork).GetModelList(func);
        // }

        // public IEnumerable<Question> FindModelList(Expression<Func<Question,bool>> func=null,Func<IQueryable<Question>, IOrderedQueryable<Question>> order = null, int pagesize = 10, int index = 1)
        // {
        //     return new QuestionRepoistory(IUnitOfWork).GetModelList(func,order,pagesize,index);
        // }
        #endregion

        public Question Add(Question entity)
        {
            return questionrepoistory.Insert(entity);
        }

        public void Add(IEnumerable<Question> entity)
        {
            questionrepoistory.Insert(entity);
        }

        public void Delete(params object[] id)
        {
            var temp = questionrepoistory.Find(id);
            questionrepoistory.Delete(temp);
        }

        public void Delete(IEnumerable<Question> entity)
        {
            questionrepoistory.Delete(entity);
            
        }

        public void UpDate(Question entity)
        {
            questionrepoistory.Update(entity);
        }

        public void UpDate(IEnumerable<Question> entity)
        {
            questionrepoistory.Update(entity);
        }

        public Question FindModel(params object[] arr)
        {
            return questionrepoistory.Find(arr);
        }

        public IEnumerable<Question> FindModelList()
        {
           return questionrepoistory.GetModelList();
        }

        public IEnumerable<Question> FindModelList(Expression<Func<Question, bool>> func)
        {
            return questionrepoistory.GetModelList(func);
        }

        public IEnumerable<Question> FindModelList(Expression<Func<Question, bool>> func = null, Func<IQueryable<Question>, IOrderedQueryable<Question>> order = null, int pagesize = 10, int index = 1)
        {
            return questionrepoistory.GetModelList(func, order, pagesize, index);
        }


        public void Delete(Expression<Func<Question, bool>> func)
        {
            questionrepoistory.Delete(func);
        }
    }
}

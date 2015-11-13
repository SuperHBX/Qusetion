﻿using QADAL.EntityFrameWorkCore;
using QADAL.EntityFrameWorkCore.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAServer.Server
{
    public  class SelectOptionServer:BaseServer,IBaseServer<QADAL.EntityFrameWorkCore.Models.Select_Option>
    {
        SelectOptionRepoistory selectoptionrepoistory;
        public SelectOptionServer() 
            : base(new QuestionContext()) 
        {
            selectoptionrepoistory = new SelectOptionRepoistory(IUnitOfWork);        
        }


        public QADAL.EntityFrameWorkCore.Models.Select_Option Add(QADAL.EntityFrameWorkCore.Models.Select_Option entity)
        {
           return selectoptionrepoistory.Insert(entity);
            
        }

        public void Add(IEnumerable<QADAL.EntityFrameWorkCore.Models.Select_Option> entity)
        {
            selectoptionrepoistory.Insert(entity);
        }

        public void Delete(params object[] id)
        {
            var temp = selectoptionrepoistory.Find(id);
            selectoptionrepoistory.Delete(temp);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<QADAL.EntityFrameWorkCore.Models.Select_Option, bool>> func)
        {
            
        }

        public void Delete(IEnumerable<QADAL.EntityFrameWorkCore.Models.Select_Option> entity)
        {
            throw new NotImplementedException();
        }

        public void UpDate(QADAL.EntityFrameWorkCore.Models.Select_Option entity)
        {
            throw new NotImplementedException();
        }

        public void UpDate(IEnumerable<QADAL.EntityFrameWorkCore.Models.Select_Option> entity)
        {
            throw new NotImplementedException();
        }

        public QADAL.EntityFrameWorkCore.Models.Select_Option FindModel(params object[] arr)
        {
            return selectoptionrepoistory.Find(arr);
        }

        public IEnumerable<QADAL.EntityFrameWorkCore.Models.Select_Option> FindModelList()
        {
            return selectoptionrepoistory.GetModelList();
        }

        public IEnumerable<QADAL.EntityFrameWorkCore.Models.Select_Option> FindModelList(System.Linq.Expressions.Expression<Func<QADAL.EntityFrameWorkCore.Models.Select_Option, bool>> func)
        {
           return selectoptionrepoistory.GetModelList(func);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace QADAL.EntityFrameWorkCore.UnitOfWorkCore
{
    public interface IRepository<TEntity> where TEntity : Models.ModelBase
    {

      

        /// <summary>
        /// 添加实体并提交到数据服务器
        /// </summary>
        TEntity Insert(TEntity item);

        /// <summary>
        /// 移除实体并提交到数据服务器
        /// 如果表存在约束，需要先删除子表信息
        /// </summary>
        void Delete(TEntity item);

        /// <summary>
        /// 修改实体并提交到数据服务器
        /// </summary>
        void Update(TEntity item);

        /// <summary>
        /// 获取TEntity类型的集合数据
        /// </summary>
        /// <param name="func">实体表达式</param>
        /// <param name="order">排序</param>
        /// <param name="pagesize">每页大小</param>
        /// <param name="index">页码</param>
        /// <returns>TEntity集合信息</returns>
        IQueryable<TEntity> GetModelList(Expression<Func<TEntity, bool>> func = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null, int pagesize = 10,int index = 1);

        /// <summary>
        /// 根据主键得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Find(params object[] id);
    }
}

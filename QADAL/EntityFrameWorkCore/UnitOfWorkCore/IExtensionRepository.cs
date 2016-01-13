using System;
using System.Collections.Generic;
using System.Linq;

namespace QADAL.EntityFrameWorkCore.UnitOfWorkCore
{
    /// <summary>
    /// 扩展的Repository操作规范
    /// </summary>
    public interface IExtensionRepository<TEntity> where TEntity : Models.ModelBase
    {
        /// <summary>
        /// 添加集合
        /// </summary>
        /// <param name="item"></param>
        void Insert(IEnumerable<TEntity> item);

        /// <summary>
        /// 修改集合
        /// </summary>
        /// <param name="item"></param>
        void Update(IEnumerable<TEntity> item);

        /// <summary>
        /// 删除集合
        /// </summary>
        /// <param name="item"></param>
        void Delete(IEnumerable<TEntity> item);

        /// <summary>
        /// 扩展更新方法，只对EF支持
        /// </summary>
        /// <param name="entity"></param>
        void Update(System.Linq.Expressions.Expression<Action<TEntity>> entity);

        void Delete(System.Linq.Expressions.Expression<Func<TEntity,bool>> func);
    }
}

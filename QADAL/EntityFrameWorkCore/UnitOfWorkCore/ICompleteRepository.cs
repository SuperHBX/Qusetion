
namespace QADAL.EntityFrameWorkCore.UnitOfWorkCore
{
    /// <summary>
    /// 完整的数据操作接口
    /// </summary>
    public interface ICompleteRepository<T> : IRepository<T>, IExtensionRepository<T> where T : QADAL.EntityFrameWorkCore.Models.Modelbase
    {
    }
}

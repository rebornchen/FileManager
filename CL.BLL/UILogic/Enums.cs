using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.UI.Logic
{

    /// <summary>
    /// 文件存储位置的计算方式
    /// </summary>
    public enum EnumFileDirSaveMethod
    {
        /// <summary>
        /// 时间优先
        /// </summary>
        DateFirst,
        /// <summary>
        /// 类型优先
        /// </summary>
        CategoryFirst
    }

    /// <summary>
    /// 文件比较的结果
    /// </summary>
    public enum EnumFileCompareResult
    {
        /// <summary>
        /// 无可比性
        /// </summary>
        ErrorCompare,
        /// <summary>
        /// 第一个比较新
        /// </summary>
        FirstIsNew,
        /// <summary>
        /// 第二个比较新
        /// </summary>
        SecondIsNew,
        /// <summary>
        /// 更新时间一样，认为相同
        /// </summary>
        Same
    }

    /// <summary>
    /// 文件比较的更新类型
    /// </summary>
    public enum CompareUpdateCategory
    {
        PhysicalDeleted,        //物理文件已删除
        UpdateTimeInconsistent, //更新时间不一致
        NewFile                 //新增物理文件
    }
}

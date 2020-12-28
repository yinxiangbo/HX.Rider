using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// 分页实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T>
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public List<T> DataList { get; set; }
        /// <summary>
        /// 构造行数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="count"></param>
        /// <param name="dataList"></param>
        public PagedList(List<T> dataList,int pageSize,int pageIndex,int count)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.TotalCount = count;
            this.DataList = dataList;
        }
    }
}

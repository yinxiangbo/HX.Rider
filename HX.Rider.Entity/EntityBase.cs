using System;

namespace HX.Rider.Entity
{
    /// <summary>
    /// 基础实体
    /// </summary>
    public class EntityBase
    {

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long CreatedBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public long UpdatedBy { get; set; }
    }
}

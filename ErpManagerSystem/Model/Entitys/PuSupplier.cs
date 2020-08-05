using System;
using System.Collections.Generic;

namespace Model.Entitys
{
    /// <summary>
    /// 供应商实体
    /// </summary>
    public partial class PuSupplier
    {
        public PuSupplier()
        {
            PuCommodity = new HashSet<PuCommodity>();
        }

        public int Id { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Linkman { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string Qq { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public string Weixin { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 信誉值
        /// </summary>
        public string Credit { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }

        public virtual AcStaff Operator { get; set; }
        public virtual ICollection<PuCommodity> PuCommodity { get; set; }
    }
}
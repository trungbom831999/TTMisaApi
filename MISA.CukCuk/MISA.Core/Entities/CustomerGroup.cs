using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin nhóm khách hàng
    /// CreatedBy: NVMANH (01/04/2021)
    /// </summary>
    public class CustomerGroup : BaseEntity
    {
        /// <summary>
        /// Khóa chính của bảng dữ liệu nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        public Guid? ParentId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin khách hàng
    /// CreatedBy: NVMANH (01/04/2021)
    /// </summary>
    public class Customer : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        ///  Họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        ///  Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (0- Nữ, 1- Nam)
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        ///  MÃ thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        ///  Khóa ngoại (FK) - nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        ///  Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế của công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  Nơi ở
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
    }
}

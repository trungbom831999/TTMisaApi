using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    public class CustomerGroupController : BaseEntityController<CustomerGroup>
    {
        public CustomerGroupController(IBaseService<CustomerGroup> baseService) : base(baseService)
        {

        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng cần chỉnh sửa</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: NVMANH (01/04/2021)
        [HttpPut("{customerId}")]
        public IActionResult Put(CustomerGroup customer, Guid customerId)
        {
                return Ok(customer);
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Khóa chính bảng thông tin khách hàng</param>
        /// <returns>
        ///  - HttpCode: 200 nếu xóa thành công
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: NVMANH (01/04/2021)
        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
                return Ok();
        }
    }
}

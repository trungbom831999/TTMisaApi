using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MISA.CukCuk.Api.Extensions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Api cho đối tượng khách hàng
    /// </summary>
    public class CustomerController : BaseEntityController<Customer>
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) :base(customerService)
        {
            _customerService = customerService;
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
        public IActionResult Put(Customer customer, Guid customerId)
        {
            // Validate dữ liệu:
            // - check trùng mã:

            // Kiểm tra xem có khách hàng nào có mã tương tự hay không?:
            var sqlCheckExitCode = $"Select CustomerCode from Customer Where CustomerCode = @CustomerCode AND CustomerId <> '{customerId}'";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", customer.CustomerCode);
            var customerExitsCode = _dbConnection.Query<string>(sqlCheckExitCode, dynamicParameters);
            if (customerExitsCode.Count() > 0)
            {
                var erroInfo = new
                {
                    devMsg = "CustomerCode duplucate!",
                    userMsg = "Thông tin mã khách hàng không được phép để trống",
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };

                return BadRequest(erroInfo);
            }
            customer.CustomerId = customerId;
            // Thực hiện lấy dữ liệu từ Database:

            var storeName = "Proc_UpdateCustomer";
            var storeParam = customer;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            // Kiểm tra kết quả và trả về cho Client:
            if (rowAffects == 0)
                return NoContent();
            else
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
            // Thực hiện xóa dữ liệu từ Database:
            var storeParam = new
            {
                CustomerId = customerId
            };
            var rowEffects = _dbConnection.Execute("Proc_DeleteCustomer", param: storeParam, commandType: CommandType.StoredProcedure);
            // Kiểm tra kết quả và trả về cho Client:
            if (rowEffects == 0)
            {
                return NoContent();
            }
            else
                return Ok(rowEffects);
        }

        protected override void ValidateData(Customer entity)
        {
            base.ValidateData(entity);
            // Check mã khách hàng đã nhập hay chưa:
            CustomerValidate.CheckCustomerCodeEmpty(entity.CustomerCode);

            //Check trùng mã:
            CustomerValidate.CheckDuplicateCustomerCode(entity.CustomerCode);
        }
    }
}

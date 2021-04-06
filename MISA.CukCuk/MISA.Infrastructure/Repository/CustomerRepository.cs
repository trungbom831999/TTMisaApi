using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public bool CheckCustomerCode(string customercode)
        {
           
            // Validate dữ liệu:
            // - check trùng mã:
            // Kiểm tra xem có khách hàng nào có mã tương tự hay không?:
            var sqlCheckExitCode = "Select CustomerCode from Customer Where CustomerCode = @CustomerCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerCode", customercode);
            var customerExitsCode = _dbConnection.Query<string>(sqlCheckExitCode, dynamicParameters);
            //if (customerExitsCode.Count() > 0)
            //{
            //    var erroInfo = new
            //    {
            //        devMsg = "CustomerCode duplucate!",
            //        userMsg = "Thông tin mã khách hàng không được phép để trống",
            //        errorCode = "misa-001",
            //        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
            //        traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
            //    };
            //}
            return true;
        }
    }
}

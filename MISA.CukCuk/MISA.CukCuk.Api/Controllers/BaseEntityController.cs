using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public abstract class BaseEntityController<MISAEntity> : ControllerBase
    {
        protected string _tableName = string.Empty;
        protected string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database= MF0_NVManh_CukCuk02";
        protected IDbConnection _dbConnection;
        IBaseService<MISAEntity> _baseService;

        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }


        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Nếu có dữ liệu: trả vễ HttpCode 200; 204 nếu không có dữ liệu</returns>
        /// CreatedBy: NVMANH (01/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        /// <param name="entityId">Id của bảng dữ liệu</param>
        /// <returns>Thông tin của 1 đối tượng</returns>
        /// CreatedBy: NKTrung (07/04/2021)
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            // Thực hiện lấy dữ liệu từ Database:
            var customer = _baseService.GetById(entityId);
            // Kiểm tra kết quả và trả về cho Client:
            if (customer == null)
                return NoContent();
            else
                return Ok(customer);
        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Khách hàng muốn thêm mới</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exception xảy ra trên Server
        /// </returns>
        /// CreatedBy: NKTrung (07/04/2021)
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            // Validate dữ liệu:
            ValidateData(entity);
            // Thực hiện lấy dữ liệu từ Database:
            var rowAffects = _baseService.Insert(entity);
            // Kiểm tra kết quả và trả về cho Client:
            if (rowAffects == 0)
                return NoContent();
            else
                return Ok(entity);
        }

        protected virtual void ValidateData(MISAEntity entity)
        {

        }
    }
}

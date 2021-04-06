using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces
{
    /// <summary>
    /// Base Repository
    /// </summary>
    /// <typeparam name="MISAEntity">Kiểu của thực thể</typeparam>
    /// CreatedBy: NVMANH (02/04/2021)
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu của bảng trong database
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: NVMANH (02/04/2021)
        IEnumerable<MISAEntity> GetEntities();

        /// <summary>
        /// Lấy thông tin của thực thể theo khóa chính
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>1 thực thể duy nhất có Id tương ứng</returns>
        /// CreatedBy: NVMANH (02/04/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>số bản ghi thêm mới được vào Db</returns>
        /// CreatedBy: NVMANH (02/04/2021)
        int Insert(MISAEntity entity);

        /// <summary>
        /// Sửa thông tin của đối tượng
        /// </summary>
        /// <param name="entity">Thực thể đã được chỉnh sửa</param>
        /// <param name="entityId">ID của thực thể</param>
        /// <returns>Số bản ghi đã update được trong Db</returns>
        /// CreatedBy: NVMANH (02/04/2021)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Khóa chính của thực thể</param>
        /// <returns>Số bản ghi đã xóa được trong Db</returns>
        /// CreatedBy: NVMANH (02/04/2021)
        int Delete(Guid entityId);
    }
}

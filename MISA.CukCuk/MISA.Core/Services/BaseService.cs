using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public IEnumerable<MISAEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }
        public MISAEntity GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

       

        public int Insert(MISAEntity entity)
        {
            // Validate nghiệp vụ:

            // Thực hiện thêm mới:
            _baseRepository.Insert(entity);
            throw new NotImplementedException();
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

    }
}

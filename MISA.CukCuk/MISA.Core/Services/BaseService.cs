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
            return _baseRepository.GetById(entityId);
        }

       

        public int Insert(MISAEntity entity)
        {
            return _baseRepository.Insert(entity);
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            return _baseRepository.Update(entity, entityId);
        }

        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

    }
}

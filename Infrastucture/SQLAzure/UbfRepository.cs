using System;
using System.Linq;
using Infrastructure.Interfacies.DTO;
using Infrastructure.Interfacies.Interfacies;
using Infrastucture.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.SQLAzure
{
    public class UbfRepository : IUbfRepository
    {
        private readonly DbContext _dbContext;

        public UbfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UbfDTO GetByKey(Guid key)
        {
            var ubf = _dbContext.Set<Ubf>()
                        .First(u => u.Id == key);
            return UbfDTOMapper.ToUbfDTO(ubf);
        }

        public IQueryable<UbfDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Guid Create(UbfDTO entity)
        {
            var ubf = UbfDTOMapper.ToUbf(entity);
            _dbContext.Add(ubf);
            _dbContext.SaveChanges();
            return ubf.Id;
        }

        public void Delete(UbfDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UbfDTO entity)
        {
            var ubf = UbfDTOMapper.ToUbf(entity);

            var entry = _dbContext.Set<Ubf>()
                        .First(u => u.Id == ubf.Id);
            entry.ProducerId = ubf.ProducerId;
            entry.Status = ubf.Status;

            _dbContext.SaveChanges();
        }
    }
}
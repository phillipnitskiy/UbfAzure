using Infrastructure.Interfacies.DTO;
using Infrastucture.Models;

namespace Infrastucture.Mappers
{
    public static class UbfDTOMapper
    {
        public static UbfDTO ToUbfDTO(Ubf ubf)
        {
            return new UbfDTO
            {
                Id = ubf.Id,
                ProducerId = ubf.ProducerId,
                Status = ubf.Status
            };
        }

        public static Ubf ToUbf(UbfDTO ubfDTO)
        {
            return new Ubf
            {
                Id = ubfDTO.Id,
                ProducerId = ubfDTO.ProducerId,
                Status = ubfDTO.Status
            };
        }
    }
}
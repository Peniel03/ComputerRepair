using ComputerRepair.BusinessLogic.Exceptions;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.RepositoryServices
{
    public class RepairingTypeService: IRepairingTypeService
    {
        private readonly IRepairingTypeRepository _repairingTypeRepository;
        public RepairingTypeService(IRepairingTypeRepository repairingTypeRepository)
        {
            _repairingTypeRepository = repairingTypeRepository;
        }

        public async Task<RepairingType> AddAsync(RepairingType  repairingType)
        {
            var repairingTypeLooked = _repairingTypeRepository.GetRepairingTypeByNameAsync(repairingType.RepairingTypeName);

            if (repairingTypeLooked is not null)
            {
                throw new ExistException("This repairing type already exist");
            }

            _repairingTypeRepository.Add(repairingType);
            await _repairingTypeRepository.SavechangesAsync();

            return repairingType;

        }

        public async Task<RepairingType> DeleteAsync(RepairingType repairingType)
        {
            var repairingTypeLooked = await _repairingTypeRepository.GetByIdAsync(repairingType.RepairingTypeId);

            if (repairingTypeLooked is null)
            {
                throw new NotFoundException("This repairing type does not exist");
            }
            _repairingTypeRepository.DeleteAsync(repairingTypeLooked);
            await _repairingTypeRepository.SavechangesAsync();
            return repairingType;
        }

        public async Task<List<RepairingType>> GetAllAsync()
        {
            var repairingTypes = await _repairingTypeRepository.GetAllAsync();

            if (repairingTypes is null)
            {
                throw new NotFoundException("There are no repairing type  yet");
            }
            return  repairingTypes;
        }

        public async Task<RepairingType?> GetByIdAsync(int Id)
        {
            var repairingType = await _repairingTypeRepository.GetByIdAsync(Id);
            if (repairingType is null)
            {
                throw new NotFoundException("The  repairing type does not exist");
            }
            return repairingType;
        }

        public async Task<RepairingType?> GetRepairingTypeByNameAsync(string RepairingTypeName)
        {
            var repairingType = await _repairingTypeRepository.GetRepairingTypeByNameAsync(RepairingTypeName);

            if (repairingType is null)
            {
                throw new NotFoundException("The repairing type does not exist");
            }

            return repairingType;
        }

        public Task SavechangesAsync()
        {
            return _repairingTypeRepository.SavechangesAsync();
         }

        public async Task<RepairingType> UpdateAsync(RepairingType repairingType)
        {
            var repairingTypeLooked = await _repairingTypeRepository.GetRepairingTypeByNameAsync(repairingType.RepairingTypeName);


            if (repairingTypeLooked is null)
            {
                throw new NotFoundException("The RepairingType does not exist");
            }

            repairingTypeLooked.RepairingTypeName = repairingType.RepairingTypeName;
            _repairingTypeRepository.UpdateAsync(repairingTypeLooked);
            await _repairingTypeRepository.SavechangesAsync();

            return repairingType;
        }

    }
}

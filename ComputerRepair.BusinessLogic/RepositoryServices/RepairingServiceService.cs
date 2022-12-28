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
    public class RepairingServiceService: IRepairingServiceService
    {
        private readonly IRepairingServiceRepository _repairingServiceRepository;
        public RepairingServiceService(IRepairingServiceRepository repairingServiceRepository)
        {
            _repairingServiceRepository = repairingServiceRepository;
        }

        public async Task<RepairingService> AddAsync(RepairingService repairingService)
        {
            var repairingServiceLooked = _repairingServiceRepository.GetRepairingServiceByNameAsync(repairingService.ServiceName);

            if (repairingServiceLooked is not null)
            {
                throw new ExistException("This repairing service already exist");
            }

            _repairingServiceRepository.Add(repairingService);
            await _repairingServiceRepository.SavechangesAsync();

            return repairingService;
        }

        public async Task<RepairingService> DeleteAsync(RepairingService repairingService)
        {
            var repairingServiceLooked = await _repairingServiceRepository.GetByIdAsync(repairingService.RepairingServiceId);

            if (repairingServiceLooked is null)
            {
                throw new NotFoundException("This repairing service does not exist");
            }
            _repairingServiceRepository.DeleteAsync(repairingServiceLooked);
            await _repairingServiceRepository.SavechangesAsync();
            return repairingService;
        }

        public async Task<List<RepairingService>> GetAllAsync()
        {
            var repairingServices = await _repairingServiceRepository.GetAllAsync();

            if (repairingServices is null)
            {
                throw new NotFoundException("There are no repairing service yet");
            }
            return repairingServices;
        }

        public async Task<RepairingService?> GetByIdAsync(int Id)
        {
            var repairingService = await _repairingServiceRepository.GetByIdAsync(Id);
            if (repairingService is null)
            {
                throw new NotFoundException("The  repairing service does not exist");
            }
            return repairingService;
        }

        public async Task<RepairingService?> GetRepairingServiceByNameAsync(string ServiceName)
        {
            var repairingService = await _repairingServiceRepository.GetRepairingServiceByNameAsync(ServiceName);
            if (repairingService is null)
            {
                throw new NotFoundException("The  repairing service does not exist");
            }
            return repairingService;
        }

        public async Task<RepairingService?> GetRepairingServiceByPriceAsync(decimal ServicePrice)
        {
            var repairingService = await _repairingServiceRepository.GetRepairingServiceByPriceAsync(ServicePrice);
            if (repairingService is null)
            {
                throw new NotFoundException("The  repairing service does not exist");
            }
            return repairingService;
        }

        public Task SavechangesAsync()
        {
            return _repairingServiceRepository.SavechangesAsync();
         }

        public async Task<RepairingService> UpdateAsync(RepairingService repairingService)
        {
            var repairingServiceLooked = await _repairingServiceRepository.GetRepairingServiceByNameAsync(repairingService.ServiceName);

            if (repairingServiceLooked is null)
            {
                throw new NotFoundException("The Repairing team does not exist");
            }

            repairingServiceLooked.ServiceName = repairingService.ServiceName;
            repairingServiceLooked.ServicePrice = repairingService.ServicePrice;
            _repairingServiceRepository.UpdateAsync(repairingServiceLooked);
            await _repairingServiceRepository.SavechangesAsync();

            return repairingService;
        }
    }
}
